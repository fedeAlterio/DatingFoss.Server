using DatingFoss.Domain;
using System.Security.Claims;
using System.Text.Json;

namespace DatingFoss.Server.Authentication.Utils;

public static class UserIdentityClaimsMapper
{
    public static IEnumerable<Claim> ClaimsFromUserIdentity(UserIdentity userIdentity)
    {
        var publicKeyJson = JsonSerializer.Serialize(userIdentity.PublicKey);
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, userIdentity.Username!),
            new Claim(nameof(UserIdentity.PublicKey), publicKeyJson)
        };
        return claims;
    }

    public static UserIdentity UserIdentityFromClaimsIdentity(ClaimsIdentity claimsIdentity)
    {
        var username = claimsIdentity.FindFirst(ClaimTypes.Name)!.Value;
        var rsaPublicKeyJson = claimsIdentity.FindFirst(nameof(UserIdentity.PublicKey))!.Value;
        var rsaPublicKey = JsonSerializer.Deserialize<RSAPublicKey>(rsaPublicKeyJson)!;
        return new(username, rsaPublicKey);
    }
}
