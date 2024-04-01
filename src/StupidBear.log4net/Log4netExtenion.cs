using log4net.Config;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Configuration;

namespace StupidBear.log4net
{
    public static class Log4netExtenion
    {
        public static ILoggingBuilder AddLog4net(this ILoggingBuilder builder)
        {
            builder.AddConfiguration();

            builder.Services.TryAddEnumerable(
                ServiceDescriptor.Singleton<ILoggerProvider, Log4netLoggerProvider>());
            XmlConfigurator.ConfigureAndWatch(new FileInfo("Configs/log4net.config"));
            return builder;
        }
    }
}
