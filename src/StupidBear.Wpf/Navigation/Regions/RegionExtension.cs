using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StupidBear.Core.Ioc;
using StupidBear.Core.Navigation.Regions;
using StupidBear.Wpf.Navigation.Regions.Behaviors;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace StupidBear.Wpf.Navigation.Regions
{
    public static class RegionExtension
    {
        public static IServiceCollection AddRegion(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            services.AddSingleton<RegionAdapterMappings>();
            services.AddScoped<SelectorRegionAdapter>();
            services.AddScoped<ItemsControlRegionAdapter>();
            services.AddScoped<ContentControlRegionAdapter>();

            services.AddSingleton<IRegionManager, RegionManager>();
            services.AddSingleton<IRegionNavigationContentLoader, RegionNavigationContentLoader>();
            services.AddSingleton<IRegionViewRegistry, RegionViewRegistry>();
            services.AddSingleton<IRegionBehaviorFactory, RegionBehaviorFactory>();
            services.AddSingleton<IRegionNavigationJournalEntry, RegionNavigationJournalEntry>();
            services.AddSingleton<IRegionNavigationJournal, RegionNavigationJournal>();
            services.AddSingleton<IRegionNavigationService, RegionNavigationService>();

            services.AddTransient<DelayedRegionCreationBehavior>();

            services.AddTransient<BindRegionContextToDependencyObjectBehavior>();
            services.AddTransient<RegionActiveAwareBehavior>();
            services.AddTransient<SyncRegionContextWithHostBehavior>();
            services.AddTransient<RegionManagerRegistrationBehavior>();
            services.AddTransient<RegionMemberLifetimeBehavior>();
            services.AddTransient<ClearChildViewsRegionBehavior>();
            services.AddTransient<AutoPopulateRegionBehavior>();
            services.AddTransient<DestructibleRegionBehavior>();

            return services;
        }
        public static IHost UseRegion<TShell>(this IHost host) where TShell : Window
        {
            ContainerLocator.SetContainerExtension(() => host.Services);

            var regionAdapterMappings = host.Services.GetService<RegionAdapterMappings>();
            regionAdapterMappings?.RegisterDefaultRegionAdapterMappings();

            var regionBehaviors = host.Services.GetService<IRegionBehaviorFactory>();
            regionBehaviors?.RegisterDefaultRegionBehaviors();

            RegionManager.SetRegionManager(host.Services.GetRequiredService(typeof(TShell)) as DependencyObject, host.Services.GetService<IRegionManager>());
            RegionManager.UpdateRegions();

            return host;
        }
        internal static void RegisterDefaultRegionAdapterMappings(this RegionAdapterMappings regionAdapterMappings)
        {
            regionAdapterMappings.RegisterMapping<Selector, SelectorRegionAdapter>();
            regionAdapterMappings.RegisterMapping<ItemsControl, ItemsControlRegionAdapter>();
            regionAdapterMappings.RegisterMapping<ContentControl, ContentControlRegionAdapter>();
        }
        internal static void RegisterDefaultRegionBehaviors(this IRegionBehaviorFactory regionBehaviors)
        {
            regionBehaviors.AddIfMissing<BindRegionContextToDependencyObjectBehavior>(BindRegionContextToDependencyObjectBehavior.BehaviorKey);
            regionBehaviors.AddIfMissing<RegionActiveAwareBehavior>(RegionActiveAwareBehavior.BehaviorKey);
            regionBehaviors.AddIfMissing<SyncRegionContextWithHostBehavior>(SyncRegionContextWithHostBehavior.BehaviorKey);
            regionBehaviors.AddIfMissing<RegionManagerRegistrationBehavior>(RegionManagerRegistrationBehavior.BehaviorKey);
            regionBehaviors.AddIfMissing<RegionMemberLifetimeBehavior>(RegionMemberLifetimeBehavior.BehaviorKey);
            regionBehaviors.AddIfMissing<ClearChildViewsRegionBehavior>(ClearChildViewsRegionBehavior.BehaviorKey);
            regionBehaviors.AddIfMissing<AutoPopulateRegionBehavior>(AutoPopulateRegionBehavior.BehaviorKey);
            regionBehaviors.AddIfMissing<DestructibleRegionBehavior>(DestructibleRegionBehavior.BehaviorKey);
        }
    }
}
