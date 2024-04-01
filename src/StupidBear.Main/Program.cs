using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StupidBear.Main.Views;
using StupidBear.Wpf;

namespace StupidBear.Main
{
    public class Program
    {
        [System.STAThreadAttribute()]
        public static void Main(string[] args)
        {
            HostApplicationBuilder builder = Host.CreateApplicationBuilder();
            builder.Services.AddSingleton<App>();
            builder.Services.AddScoped<MainWindow>();
            builder.Services.AddHostedService<WPFHostedService<App, MainWindow>>();
            IHost host = builder.Build();
            host.Run();
        }
    }
}
