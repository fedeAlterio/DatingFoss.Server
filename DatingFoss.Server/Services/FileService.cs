using DatingFoss.Domain.Exceptions;
using DatingFoss.Server.Services.Abstractions;
using DatingFoss.Server.Services.Exception;
using SixLabors.ImageSharp;

namespace DatingFoss.Server.Services;

public class FileService : IFileService
{
    public async Task AssertIsAnImage(Stream file, CancellationToken cancellationToken)
    {
        try
        {
            await Image.LoadAsync(file, cancellationToken);
            if (file.CanSeek)
                file.Position = 0;
        }
        catch
        {
            throw new DatingFossException($"The file is not a valid image");
        }
    }

    public void AssertIsValidFileName(string? fileName)
    {
        if (fileName is null || fileName.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
            throw new InvalidFileNameExcepion(fileName);
    }

    public async Task SaveFile(Stream file, string path, string filename, CancellationToken cancellationToken)
    {
        Directory.CreateDirectory(path);
        var fullPath = Path.Combine(path, filename);
        using var fileStream = new FileStream(fullPath, FileMode.CreateNew, FileAccess.Write);
        await file.CopyToAsync(fileStream, cancellationToken);
    }
}
