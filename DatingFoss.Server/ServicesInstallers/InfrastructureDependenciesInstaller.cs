using DatingFoss.Infrastructure.DependencyInjection;

namespace DatingFoss.Server.ServicesInstallers;

public class InfrastructureDependenciesInstaller : IDependenciesInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.UseDatingFossInfrastructure();
    }
}
