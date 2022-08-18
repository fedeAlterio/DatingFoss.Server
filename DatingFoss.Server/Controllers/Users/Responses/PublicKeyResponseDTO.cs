using DatingFoss.Server.DTOs;

namespace DatingFoss.Server.Controllers.Users.Responses;

public class PublicKeyByUsernameResponseDTO
{
    public RSAPublicKeyDTO? PublicKey { get; init; }
}
