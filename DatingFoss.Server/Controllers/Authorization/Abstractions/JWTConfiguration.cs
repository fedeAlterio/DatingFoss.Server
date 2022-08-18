namespace DatingFoss.Server.Controllers.Authorization.Abstractions;

public class JWTConfiguration
{
    public string? Issuer { get; init; }
    public string? Audience { get; init; }
    public string? Key { get; init; }
    public int MinutesBeforeExpiration { get; init; }
}
