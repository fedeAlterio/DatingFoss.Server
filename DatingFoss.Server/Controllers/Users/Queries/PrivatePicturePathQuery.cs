using DatingFoss.Server.Controllers.Users.Responses;
using MediatR;

namespace DatingFoss.Server.Controllers.Users.Queries;

public class PrivatePicturePathQuery : IRequest<PrivatePictureResponseDTO>
{
    public string? PictureName { get; init; }
    public string? Username { get; init; }
}
