using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using StupidBear.Extensions;
using StupidBear.log4net;
using StupidBear.Main.ViewModels;
using StupidBear.Main.Views;
using StupidBear.Wpf;
using StupidBear.Wpf.Mvvm;
using StupidBear.Wpf.Navigation.Regions;

namespace StupidBear.Main
{
    public class Program
    {
        [System.STAThreadAttribute()]
        public static void Main(string[] args)
        {
            HostApplicationBuilder builder = Host.CreateApplicationBuilder();
            builder.AddModularity();
            builder.Logging.ClearProviders();
            builder.Logging.AddLog4net();

            builder.Services.AddSingleton<App>()
                .AddScoped<MainWindow>()
                .AddScoped<MainWindowViewModel>()
                .AddHostedService<WPFHostedService<App, MainWindow>>()
                .AddRegion()
                .AddMvvm();
            IHost host = builder.Build();
            host.UseRegion();
            host.UseModularity();
            host.Run();
        }
    }
}
