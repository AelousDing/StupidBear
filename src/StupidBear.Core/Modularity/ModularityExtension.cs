using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StupidBear.Modularity;

namespace StupidBear.Extensions
{
    public static class ModularityExtension
    {
        public static IServiceCollection AddModularity(this IHostApplicationBuilder builder)
        {
            builder.Services.Configure<ModuleOptions>(builder.Configuration.GetSection(nameof(ModuleOptions)));
            var moduleOptions = builder.Configuration.GetSection(nameof(ModuleOptions)).Get<ModuleOptions>();
            if (moduleOptions != null && moduleOptions.Modules != null)
            {
                foreach (var option in moduleOptions.Modules)
                {
                    Type? moduleType = Type.GetType(option.Type);
                    if (moduleType == null) continue;
                    builder.Services.AddSingleton(moduleType);//注册各模块

                    IModule? module = builder.Services
                        .BuildServiceProvider()
                        .GetService(moduleType) as IModule;
                    module?.ConfigService(builder.Services);
                }
            }
            return builder.Services;
        }
        public static IHost UseModularity(this IHost host)
        {
            var moduleOptions = host.Services
                .GetService<IConfiguration>()
                ?.GetSection(nameof(ModuleOptions))
                .Get<ModuleOptions>();
            if (moduleOptions != null && moduleOptions.Modules != null)
            {
                foreach (var option in moduleOptions.Modules)
                {
                    Type? moduleType = Type.GetType(option.Type);
                    if (moduleType == null) continue;
                    IModule? module = host.Services.GetService(moduleType) as IModule;
                    module?.Config(host.Services);
                }
            }
            return host;
        }
    }
}
