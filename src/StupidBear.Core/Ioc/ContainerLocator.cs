using System;
using System.ComponentModel;

namespace StupidBear.Core.Ioc
{
    /// <summary>
    /// The <see cref="ContainerLocator" /> tracks the current instance of the Container used by your Application
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class ContainerLocator
    {
        private static Lazy<IServiceProvider> _lazyContainer;

        private static IServiceProvider _current;

        /// <summary>
        /// Gets the current <see cref="IContainerExtension" />.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static IServiceProvider Current =>
            _current ?? (_current = _lazyContainer?.Value);

        /// <summary>
        /// Gets the <see cref="IContainerProvider" />
        /// </summary>
        public static IServiceProvider Container =>
            Current;

        /// <summary>
        /// Sets the Container Factory to use if the Current <see cref="IContainerProvider" /> is null
        /// </summary>
        /// <param name="factory"></param>
        /// <remarks>
        /// NOTE: We want to use Lazy Initialization in case the container is first created
        /// prior to StupidBear.Core initializing which could be the case with Shiny
        /// </remarks>
        public static void SetContainerExtension(Func<IServiceProvider> factory) =>
            _lazyContainer = new Lazy<IServiceProvider>(factory);

        /// <summary>
        /// Used for Testing to Reset the Current Container
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void ResetContainer()
        {
            _current = null;
            _lazyContainer = null;
        }
    }
}
