using DatingFoss.Server.Controllers.Users.Responses;
using MediatR;

namespace DatingFoss.Server.Controllers.Users.Queries;

public record PostSymmetricKeysQuery : IRequest<PostSymmetricKeysResponseDTO>
{
    public string? SymmetricKeys { get; init; }
    public string? UserName { get; init; }
}
