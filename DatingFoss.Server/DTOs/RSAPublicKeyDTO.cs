using DatingFoss.Server.Authentication.Validation.Attributes;

namespace DatingFoss.Server.DTOs;

public record RSAPublicKeyDTO
{
    [Base64]
    public string? Modulus { get; init; }

    [Base64]
    public string? Exponent { get; init; }
}
