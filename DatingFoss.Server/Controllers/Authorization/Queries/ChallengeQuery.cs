using DatingFoss.Server.Controllers.Authorization.Responses;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace DatingFoss.Server.Controllers.Authorization.Queries;

public class ChallengeQuery : IRequest<ChallengeResponseDTO>
{
    [Required]
    public string? Username { get; init; }
}
