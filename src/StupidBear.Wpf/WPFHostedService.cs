using Microsoft.Extensions.Hosting;
using System.Windows;

namespace StupidBear.Wpf
{
    public class WPFHostedService<TApplication, TWindow> : IHostedService
        where TApplication : Application
        where TWindow : Window
    {
        private TApplication app;
        private TWindow window;
        private IHostApplicationLifetime applicationLifetime;
        public WPFHostedService(TApplication app, TWindow window, IHostApplicationLifetime applicationLifetime)
        {
            this.app = app;
            this.window = window;
            this.applicationLifetime = applicationLifetime;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            app.Exit += App_Exit;//处理推出的时候，停止主机,.NET6+需要
            app.Run(window);

            return Task.CompletedTask;
        }

        private void App_Exit(object sender, ExitEventArgs e)
        {
            applicationLifetime.StopApplication();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
