using Microsoft.Extensions.DependencyInjection;

namespace StupidBear.Modularity
{
    public interface IModule
    {
        void ConfigService(IServiceCollection services);
        void Config(IServiceProvider services);
    }
}
