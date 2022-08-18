using DatingFoss.Server.Services.Abstractions;
using DatingFoss.Server.ServicesInstallers;

namespace DatingFoss.Server.Services;

public class FileServiceInstaller : IDependenciesInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IFileService, FileService>();
    }
}
