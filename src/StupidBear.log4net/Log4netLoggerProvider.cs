using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;
using System.Runtime.Versioning;

namespace StupidBear.log4net
{
    [UnsupportedOSPlatform("browser")]
    [ProviderAlias("Log4net")]
    public class Log4netLoggerProvider : ILoggerProvider
    {
        private readonly ConcurrentDictionary<string, Log4netLogger> loggers =
        new(StringComparer.OrdinalIgnoreCase);
        public ILogger CreateLogger(string categoryName)
        {
            return loggers.GetOrAdd(categoryName, name => new Log4netLogger(name)); ;
        }

        public void Dispose()
        {

        }
    }
}
