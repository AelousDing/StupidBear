using Microsoft.Extensions.DependencyInjection;
using StupidBear.Core.Navigation.Regions;
using StupidBear.Modularity;
using StupidBear.ModuleA.ViewModels;
using StupidBear.ModuleA.Views;

namespace StupidBear.ModuleA
{
    public class ModuleAModule : IModule
    {
        public void Config(IServiceProvider services)
        {
            var regionManager = services.GetService<IRegionManager>();
            regionManager?.RegisterViewWithRegion("ContentRegion", typeof(ViewA));
        }

        public void ConfigService(IServiceCollection services)
        {
            services.AddTransient<ViewA>();
            services.AddTransient<ViewAViewModel>();
        }
    }
}
