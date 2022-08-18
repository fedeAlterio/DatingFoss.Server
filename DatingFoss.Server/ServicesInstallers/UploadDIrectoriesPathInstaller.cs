using DatingFoss.Server.Configuration;
using DatingFoss.Server.Configuration.Abstractions;

namespace DatingFoss.Server.ServicesInstallers;

public class UploadDIrectoriesPathInstaller : IDependenciesInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IDirectoriesInfo, DirectoriesInfo>();
    }
}
