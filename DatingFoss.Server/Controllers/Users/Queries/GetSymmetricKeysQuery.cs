using DatingFoss.Server.Controllers.Users.Responses;
using MediatR;

namespace DatingFoss.Server.Controllers.Users.Queries;

public record GetSymmetricKeysQuery : IRequest<GetSymmetricKeysResponseDTO>
{
    public string? UserName { get; init; }
}
