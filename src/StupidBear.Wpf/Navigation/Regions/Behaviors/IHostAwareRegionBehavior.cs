

using StupidBear.Core.Navigation.Regions;
using System.Windows;

namespace StupidBear.Wpf.Navigation.Regions.Behaviors
{
    /// <summary>
    /// Defines a <see cref="IRegionBehavior"/> that not allows extensible behaviors on regions which also interact
    /// with the target element that the <see cref="IRegion"/> is attached to.
    /// </summary>
    public interface IHostAwareRegionBehavior : IRegionBehavior
    {
        /// <summary>
        /// Gets or sets the <see cref="DependencyObject"/> that the <see cref="IRegion"/> is attached to.
        /// </summary>
        /// <value>A <see cref="DependencyObject"/> that the <see cref="IRegion"/> is attached to.
        /// This is usually a <see cref="FrameworkElement"/> that is part of the tree.</value>
        DependencyObject HostControl { get; set; }
    }
}
