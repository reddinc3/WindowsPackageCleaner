using Autofac;
using System.Windows;
using WindowsPackageCleaner.Client.AutoFacModules;

namespace WindowsPackageCleaner.Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Initialise an AutoFac container to be used throughout the application on startup.
        /// </summary>
        /// <param name="e">Any arguments provided on startup.</param>
        protected override void OnStartup(StartupEventArgs e)
        {
            ContainerBuilder containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule(new WindowPackageCleanerModule());
            IContainer container = containerBuilder.Build();

            using (ILifetimeScope scope = container.BeginLifetimeScope())
            {
                MainWindow window = scope.Resolve<MainWindow>();
                window.Show();
            }
        }
    }
}