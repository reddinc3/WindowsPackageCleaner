using System.Collections.ObjectModel;
using Windows.ApplicationModel;

namespace WindowsPackageCleaner.Client.ViewModel
{
    /// <summary>
    /// A View-Model class for the WindowsPackageManager application.
    /// </summary>
    public class WindowsPackageManagerViewModel
    {
        /// <summary>
        /// Initialise an instance of the <see cref="WindowsPackageManagerViewModel"/> class.
        /// </summary>
        public WindowsPackageManagerViewModel() => RetrieveInstalledPackages();

        /// <summary>
        /// Represents the packages currently being presented on the WindowsPackageManager view.
        /// </summary>
        public ObservableCollection<Package> Packages { get; private set; }

        /// <summary>
        /// Retrieve the installed packages on the user's machine when the application loads.
        /// </summary>
        private void RetrieveInstalledPackages()
        {
            ObservableCollection<Package> packages = new ObservableCollection<Package>();
            Packages = packages;
        }
    }
}