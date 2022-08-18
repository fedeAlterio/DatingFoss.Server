using DatingFoss.Server.Authentication;
using DatingFoss.Server.Authentication.Validation.Attributes;
using DatingFoss.Server.Controllers.Users.Responses;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace DatingFoss.Server.Controllers.Users.Queries;

public record UploadPrivatePictureQuery : IRequest<UploadPrivatePictureResponseDTO>
{
    internal UserIdentity? UserIdentity { get; init; }


    [Required]
    [FileSize(maxSizeInBytes: 10_000_000, minSizeInBytes: 1)]
    public IFormFile? Picture { get; init; }


    [Required]
    [Range(0, int.MaxValue)]
    public int KeyIndex { get; init; }
}
