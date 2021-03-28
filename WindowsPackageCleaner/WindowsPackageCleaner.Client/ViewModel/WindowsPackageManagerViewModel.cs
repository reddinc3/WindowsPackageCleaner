using System.Collections.ObjectModel;
using Windows.ApplicationModel;

namespace WindowsPackageCleaner.Client.ViewModel
{
    class WindowsPackageManagerViewModel
    {
        public WindowsPackageManagerViewModel()
        {
            LoadPackages();
        }

        public ObservableCollection<Package> Packages
        {
            get;
            set;
        }

        public void LoadPackages()
        {
            ObservableCollection<Package> packages = new ObservableCollection<Package>();

            Packages = packages;
        }
    }
}