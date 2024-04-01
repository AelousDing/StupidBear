using MethodBoundaryAspect.Fody.Attributes;
using Microsoft.Extensions.Logging;
using StupidBear.Core.Ioc;

namespace StupidBear.Fody
{
    public class ExceptionHandleAspect : OnMethodBoundaryAspect
    {
        private Type logType;
        public ExceptionHandleAspect(Type logType)
        {
            this.logType = logType;

        }
        public override void OnException(MethodExecutionArgs arg)
        {
            var logger = ContainerLocator.Current.GetService(logType) as ILogger;
            logger?.LogError($"{arg.Instance.GetType()} {arg.Method.Name}", arg.Exception);
        }
    }
}
