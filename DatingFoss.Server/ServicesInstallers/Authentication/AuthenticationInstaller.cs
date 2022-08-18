using DatingFoss.Server.Controllers.Authorization.Abstractions;
using DatingFoss.Server.Controllers.Authorization.Services;
using DatingFoss.Server.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace DatingFoss.Server.ServicesInstallers.Authentication;

public class AuthenticationInstaller : IDependenciesInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        var jwtConfiguration = configuration.Get<JWTConfiguration>("JWT");
        services.AddSingleton(jwtConfiguration);
        services.AddSingleton<IJWTService, JWTService>();
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtConfiguration.Issuer,
                ValidAudience = jwtConfiguration.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfiguration.Key!))
            };
        });
    }
}
