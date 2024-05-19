using Microsoft.Extensions.DependencyInjection;

namespace StupidBear.Core.Ioc
{
    public static class ContainerExtension
    {
        public static bool IsRegistered(this IServiceProvider serviceProvider, Type type)
        {
            return serviceProvider.GetService(type) == null ? false : true;
        }
        public static bool IsRegistered(this IServiceProvider serviceProvider, Type type, string name)
        {
            return serviceProvider.GetService(type) == null ? false : true;
        }
        public static Type GetRegistrationType(this IServiceProvider serviceProvider, Type type)
        {
            return serviceProvider.GetService(type).GetType();
        }
        public static Type GetRegistrationType(this IServiceProvider serviceProvider, string name)
        {
            var type= Type.GetType(name);
            return serviceProvider.GetService(type).GetType();
        }
        public static Type? GetService<T>(this IServiceProvider serviceProvider, string name)
        {
            return serviceProvider.GetServices(typeof(T)).FirstOrDefault(p => p.GetType().Name == name)?.GetType();
        }
    }
}
