using DatingFoss.Server.Configuration.Abstractions;
using DatingFoss.Server.Controllers.Users.Queries;
using DatingFoss.Server.Controllers.Users.Responses;
using DatingFoss.Server.Services.Abstractions;
using MediatR;
using Microsoft.AspNetCore.StaticFiles;

namespace DatingFoss.Server.Controllers.Users.QueyHandlers;

public class PrivatePicturePathQueryHandler : IRequestHandler<PrivatePicturePathQuery, PrivatePictureResponseDTO>
{
    private readonly IDirectoriesInfo _directoriesInfo;
    private readonly IFileService _fileService;

    public PrivatePicturePathQueryHandler(IDirectoriesInfo directoriesInfo, IFileService fileService)
    {
        _directoriesInfo = directoriesInfo;
        _fileService = fileService;
    }

    public Task<PrivatePictureResponseDTO> Handle(PrivatePicturePathQuery request, CancellationToken cancellationToken)
    {
        var privatePicturesPath = _directoriesInfo.GetPrivatePicturesPath(request.Username!);
        _fileService.AssertIsValidFileName(request.PictureName);
        var fullPath = Path.Combine(privatePicturesPath, request.PictureName!);
        var contentType = GetContentType(fullPath);
        var ret = new PrivatePictureResponseDTO { PicutrePath = fullPath, ContentType = contentType };
        return Task.FromResult(ret);
    }

    private string GetContentType(string filename)
    {
        new FileExtensionContentTypeProvider().TryGetContentType(filename, out var contentType);
        return contentType ?? "application/octet-stream";
    }
}
