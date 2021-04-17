using System.Collections.ObjectModel;
using WindowsPackageCleaner.Client.Helpers.Interfaces;
using WindowsPackageCleaner.Client.Models;

namespace WindowsPackageCleaner.Client.ViewModel
{
    /// <summary>
    /// A View-Model class for the WindowsPackageManager application.
    /// </summary>
    public class WindowsPackageManagerViewModel
    {
        /// <summary>
        /// An instance of the <see cref="IWindowsPackageManager"/> to handle all Windows 8/10 package management.
        /// </summary>
        private readonly IWindowsPackageManager _windowsPackageManager;

        /// <summary>
        /// Represents the packages currently being presented on the WindowsPackageManager view.
        /// </summary>
        public ObservableCollection<WindowsPackage> Packages { get; private set; }

        /// <summary>
        /// Initialise an instance of the <see cref="WindowsPackageManagerViewModel"/> class.
        /// </summary>
        /// <param name="windowsPackageManager">An instance of the <see cref="IWindowsPackageManager"/> to handle all Windows 8/10 package management.<param>
        public WindowsPackageManagerViewModel(IWindowsPackageManager windowsPackageManager)
        {
            _windowsPackageManager = windowsPackageManager;
            RetrieveInstalledPackages();
        }

        /// <summary>
        /// Retrieve the installed packages on the user's machine when the application loads.
        /// </summary>
        private async void RetrieveInstalledPackages()
            => Packages = new ObservableCollection<WindowsPackage>(await _windowsPackageManager.GetInstalledPackages().ConfigureAwait(true));
    }
}