using Microsoft.Extensions.DependencyInjection;
using StupidBear.Core.Ioc;
using StupidBear.Core.Mvvm;

namespace StupidBear.Wpf.Mvvm
{
    public static class MvvmExtension
    {
        public static IServiceCollection AddMvvm(this IServiceCollection services)
        {
            ViewModelLocationProvider.SetDefaultViewModelFactory((view, type) =>
            {
                return ContainerLocator.Container.GetService(type);
            });
            return services;
        }
    }
}
