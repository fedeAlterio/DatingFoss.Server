using DatingFoss.Application.Users.Requests;
using DatingFoss.Server.Configuration.Abstractions;
using DatingFoss.Server.Controllers.Users.Queries;
using DatingFoss.Server.Controllers.Users.Responses;
using DatingFoss.Server.Services.Abstractions;
using MediatR;

namespace DatingFoss.Server.Controllers.Users.QueyHandlers;

public class UploadPublicPictureQueryHandler : IRequestHandler<UploadPublicPictureQuery, UploadPublicPictureResponseDTO>
{
    private readonly IFileService _fileService;
    private readonly IDirectoriesInfo _directoriesInfo;
    private readonly IMediator _mediator;

    public UploadPublicPictureQueryHandler(IFileService fileService, IDirectoriesInfo directoriesInfo, IMediator mediator)
    {
        _fileService = fileService;
        _directoriesInfo = directoriesInfo;
        _mediator = mediator;
    }

    public async Task<UploadPublicPictureResponseDTO> Handle(UploadPublicPictureQuery request, CancellationToken cancellationToken)
    {
        using var fileStream = request.Picture!.OpenReadStream();
        using var memoryStream = new MemoryStream();
        await fileStream.CopyToAsync(memoryStream, cancellationToken);
        var (fileName, path) = GetFileDirectoryInfo(request.UserIdentity!.Username!, request.Picture);

        memoryStream.Position = 0;
        await SaveImage(memoryStream, fileName, path, cancellationToken);
        var uploadRequest = new UploadPublicPictureRequest { Picture = fileName, Username = request.UserIdentity.Username };
        try
        {
            var response = await _mediator.Send(uploadRequest, cancellationToken);
            return new() { PictureName = fileName };
        }
        catch
        {
            var fullPath = Path.Combine(path, fileName);
            File.Delete(fullPath);
            throw;
        }
    }

    private (string fileName, string path) GetFileDirectoryInfo(string username, IFormFile file)
    {
        var extension = Path.GetExtension(file.FileName);
        var fileName = Path.ChangeExtension(Path.GetRandomFileName(), extension);
        var path = _directoriesInfo.GetPublicPicturesPath(username);
        return (fileName, path);
    }

    private async Task SaveImage(MemoryStream memoryStream, string fileName, string path, CancellationToken cancellationToken)
    {
        await _fileService.AssertIsAnImage(memoryStream, cancellationToken);
        await _fileService.SaveFile(memoryStream, path, fileName, cancellationToken);
    }
}
