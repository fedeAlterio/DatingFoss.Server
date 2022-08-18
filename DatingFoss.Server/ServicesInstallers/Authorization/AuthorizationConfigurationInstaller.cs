using DatingFoss.Application.Authorization;
using DatingFoss.Server.Extensions;

namespace DatingFoss.Server.ServicesInstallers.Authorization;

public class AuthorizationConfigurationInstaller : IDependenciesInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        var authorizationConfiguration = configuration.Get<AuthorizationConfiguration>("Authorization");
        services.AddSingleton(authorizationConfiguration);
    }
}
