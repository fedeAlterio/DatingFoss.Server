namespace DatingFoss.Server.ServicesInstallers.External;

public class AutoMapperInstaller : IDependenciesInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(typeof(Program));
    }
}
