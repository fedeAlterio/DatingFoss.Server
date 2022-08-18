namespace DatingFoss.Server.Services.Abstractions;

public interface IFileService
{
    void AssertIsValidFileName(string? fileName);
    Task SaveFile(Stream file, string path, string filename, CancellationToken cancellationToken);
    Task AssertIsAnImage(Stream file, CancellationToken cancellationToken);
}
