using DatingFoss.Server.Controllers.Users.Responses;
using MediatR;

namespace DatingFoss.Server.Controllers.Users.Queries;

public class PublicPicturePathQuery : IRequest<PublicPictureResponseDTO>
{
    public string? Username { get; init; }
    public string? PictureName { get; init; }
}
