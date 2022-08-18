using DatingFoss.Server.Controllers.Authorization.Responses;
using MediatR;

namespace DatingFoss.Server.Controllers.Authorization.Queries;

public class DoesUserExistQuery : IRequest<DoesUserExistResponseDTO>
{
    public string? Username { get; init; }
}
