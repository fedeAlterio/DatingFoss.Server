namespace DatingFoss.Server.ServicesInstallers
{
    public interface IDependenciesInstaller
    {
        void Install(IServiceCollection services, IConfiguration configuration);
    }
}
