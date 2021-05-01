using Autofac;
using Windows.Management.Deployment;
using WindowsPackageCleaner.Client.Helpers;
using WindowsPackageCleaner.Client.Helpers.Interfaces;
using WindowsPackageCleaner.Client.ViewModel;

namespace WindowsPackageCleaner.Client.AutoFacModules
{
    /// <summary>
    /// Register any necessary components for the WindowsPackageCleaner application.
    /// </summary>
    public class WindowPackageCleanerModule : Module
    {
        /// <summary>
        /// Add any necessary registrations to the application's container builder. 
        /// </summary>
        /// <param name="builder">A <see cref=" ContainerBuilder"/> instance to be used to build the application's container.</param>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<PackageManager>().AsSelf();
            builder.RegisterType<WindowsPackageManager>().As<IWindowsPackageManager>().SingleInstance();
            builder.RegisterType<WindowsPackageManagerViewModel>().AsSelf();
        }
    }
}