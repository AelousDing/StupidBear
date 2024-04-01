using log4net;
using Microsoft.Extensions.Logging;

namespace StupidBear.log4net
{
    public class Log4netLogger : Microsoft.Extensions.Logging.ILogger
    {
        ILog log;
        public Log4netLogger(string name)
        {
            log = LogManager.GetLogger(name);
        }
        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            return default!;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            switch (logLevel)
            {
                case LogLevel.Trace:
                case LogLevel.Debug:
                    log.Debug(state, exception);
                    break;
                case LogLevel.Information:
                    log.Info(state, exception);
                    break;
                case LogLevel.Warning:
                    log.Warn(state, exception);
                    break;
                case LogLevel.Error:
                    log.Error(state, exception);
                    break;
                case LogLevel.Critical:
                    log.Fatal(state, exception);
                    break;
                case LogLevel.None:
                    break;
                default:
                    break;
            }
        }
    }
}
