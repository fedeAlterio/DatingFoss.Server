using DatingFoss.Server.Controllers.Users.Responses;
using MediatR;

namespace DatingFoss.Server.Controllers.Users.Queries;

public class PublicKeyByUsernameQuery : IRequest<PublicKeyByUsernameResponseDTO>
{
    public string? Username { get; init; }
}
