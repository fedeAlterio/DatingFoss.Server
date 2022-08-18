using DatingFoss.Server.Controllers.Users.Responses;
using MediatR;

namespace DatingFoss.Server.Controllers.Users.Queries;

public class UserByUsernameQuery : IRequest<UserByUsernameResponseDTO>
{
    public string? Username { get; init; }
}
