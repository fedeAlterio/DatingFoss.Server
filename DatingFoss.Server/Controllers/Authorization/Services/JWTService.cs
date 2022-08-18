using DatingFoss.Domain;
using DatingFoss.Server.Authentication;
using DatingFoss.Server.Authentication.Utils;
using DatingFoss.Server.Controllers.Authorization.Abstractions;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace DatingFoss.Server.Controllers.Authorization.Services;

public class JWTService : IJWTService
{
    private readonly JWTConfiguration _jwtConfiguration;

    public JWTService(JWTConfiguration jwtConfiguration)
    {
        _jwtConfiguration = jwtConfiguration;
    }

    public string BuildToken(User user)
    {
        var userIdentity = new UserIdentity(user.Username!, user.PublicKey!);
        var claims = UserIdentityClaimsMapper.ClaimsFromUserIdentity(userIdentity);

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfiguration.Key!));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
        var tokenDescriptor = new JwtSecurityToken(_jwtConfiguration.Issuer, _jwtConfiguration.Audience, claims,
            expires: DateTime.Now.AddMinutes(_jwtConfiguration.MinutesBeforeExpiration), signingCredentials: credentials);
        return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
    }
}
