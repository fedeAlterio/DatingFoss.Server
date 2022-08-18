namespace DatingFoss.Server.DTOs;

public record RSAPrivateKeyDTO : RSAPublicKeyDTO
{
    public string? P { get; init; }
}
