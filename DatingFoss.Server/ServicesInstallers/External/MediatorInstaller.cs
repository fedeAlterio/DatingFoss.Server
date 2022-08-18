using DatingFoss.Application;
using DatingFoss.Infrastructure;
using MediatR;

namespace DatingFoss.Server.ServicesInstallers.External
{
    public class MediatorInstaller : IDependenciesInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(typeof(IDatingFossInfrastructureDIPlaceholder),
                                typeof(IDatingFossApplicationDIPlaceholder),
                                typeof(Program));
        }
    }
}
