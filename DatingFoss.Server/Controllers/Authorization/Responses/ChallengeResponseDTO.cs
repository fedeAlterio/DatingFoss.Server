using DatingFoss.Server.DTOs;

namespace DatingFoss.Server.Controllers.Authorization.Responses;

public class ChallengeResponseDTO
{
    public TokenDTO? Token { get; init; }
}
