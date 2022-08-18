using DatingFoss.Server.Configuration.Abstractions;
using DatingFoss.Server.Controllers.Users.Queries;
using DatingFoss.Server.Controllers.Users.Responses;
using DatingFoss.Server.Services.Abstractions;
using MediatR;
using Microsoft.AspNetCore.StaticFiles;

namespace DatingFoss.Server.Controllers.Users.QueyHandlers;

public class PublicPicturePathQueryHandler : IRequestHandler<PublicPicturePathQuery, PublicPictureResponseDTO>
{
    private readonly IDirectoriesInfo _directoriesInfo;
    private readonly IFileService _fileService;

    public PublicPicturePathQueryHandler(IDirectoriesInfo directoriesInfo, IFileService fileService)
    {
        _directoriesInfo = directoriesInfo;
        _fileService = fileService;
    }

    public Task<PublicPictureResponseDTO> Handle(PublicPicturePathQuery request, CancellationToken cancellationToken)
    {
        var publicPicturesPath = _directoriesInfo.GetPublicPicturesPath(request.Username!);
        _fileService.AssertIsValidFileName(request.PictureName);
        var fullPath = Path.Combine(publicPicturesPath, request.PictureName!);
        var contentType = GetContentType(fullPath);
        var ret = new PublicPictureResponseDTO { PicutrePath = fullPath, ContentType = contentType };
        return Task.FromResult(ret);
    }


    private string GetContentType(string filename)
    {
        new FileExtensionContentTypeProvider().TryGetContentType(filename, out var contentType);
        return contentType ?? "application/octet-stream";
    }
}
