namespace DatingFoss.Server.ServicesInstallers.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void InstallServices(this IServiceCollection @this, IConfiguration configuration)
        {
            var types = from type in typeof(IDependenciesInstaller).Assembly.ExportedTypes
                        where type.IsAssignableTo(typeof(IDependenciesInstaller))
                        where !type.IsAbstract && !type.IsInterface
                        let instance = (IDependenciesInstaller?)Activator.CreateInstance(type)
                        where instance != null
                        select instance;

            foreach (var type in types)
                type.Install(@this, configuration);
        }
    }
}
