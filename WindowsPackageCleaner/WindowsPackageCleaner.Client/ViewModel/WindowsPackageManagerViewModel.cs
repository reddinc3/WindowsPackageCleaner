using System;
using System.Collections.ObjectModel;
using Windows.ApplicationModel;
using WindowsPackageCleaner.Client.Helpers;
using WindowsPackageCleaner.Client.Helpers.Interfaces;

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
        private IWindowsPackageManager _windowsPackageManager;

        /// <summary>
        /// Represents the packages currently being presented on the WindowsPackageManager view.
        /// </summary>
        public ObservableCollection<Package> Packages { get; private set; }

        /// <summary>
        /// Initialise an instance of the <see cref="WindowsPackageManagerViewModel"/> class.
        /// </summary>
        public WindowsPackageManagerViewModel()
        {
            _windowsPackageManager = new WindowsPackageManager();
            RetrieveInstalledPackages();
        }

        /// <summary>
        /// Retrieve the installed packages on the user's machine when the application loads.
        /// </summary>
        private async void RetrieveInstalledPackages()
            => Packages = new ObservableCollection<Package>(await _windowsPackageManager.GetInstalledPackages().ConfigureAwait(true));
    }
}