using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace Sample.UI.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var container = new ServiceCollection();

            container.AddTransient<MainWindow>();
            container.AddTransient<MainViewModel>();
            container.AddTransient<IDialogService, WpfDialogService>();
            container.AddTransient<IImageLogic, ImageLogic>();
            container.AddTransient<IImageManager>(s => new FileSystemImageManager("Images"));

            var serviceProvider = container.BuildServiceProvider();
            serviceProvider.GetRequiredService<MainWindow>().Show();
        }
    }
}
