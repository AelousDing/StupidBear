using System;

namespace StupidBear.Core.Navigation.Regions
{
    /// <summary>
    /// EventArgs used with the Navigated event.
    /// </summary>
    public class RegionNavigationEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RegionNavigationEventArgs"/> class.
        /// </summary>
        /// <param name="navigationContext">The navigation context.</param>
        public RegionNavigationEventArgs(NavigationContext navigationContext)
        {
            NavigationContext = navigationContext ?? throw new ArgumentNullException(nameof(navigationContext));
        }

        /// <summary>
        /// Gets the navigation context.
        /// </summary>
        /// <value>The navigation context.</value>
        public NavigationContext NavigationContext { get; }

        /// <summary>
        /// Gets the navigation URI
        /// </summary>
        /// <value>The URI.</value>
        /// <remarks>
        /// This is a convenience accessor around NavigationContext.Uri.
        /// </remarks>
        public Uri Uri => NavigationContext.Uri;
    }
}
