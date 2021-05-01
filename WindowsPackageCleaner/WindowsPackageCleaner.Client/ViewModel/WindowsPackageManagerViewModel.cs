using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using WindowsPackageCleaner.Client.Commands;
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
        private IWindowsPackageManager _windowsPackageManager;

        /// <summary>
        /// Represents the packages currently being presented on the WindowsPackageManager view.
        /// </summary>
        public ObservableCollection<WindowsPackage> Packages { get; set; }

        /// <summary>
        /// A relay command to bind to the UI to allow a user to uninstall a set of packages.
        /// </summary>
        public ICommand UninstallCommand { get; private set; }

        /// <summary>
        /// Initialise an instance of the <see cref="WindowsPackageManagerViewModel"/> class.
        /// </summary>
        /// <param name="windowsPackageManager">An instance of the <see cref="IWindowsPackageManager"/> to handle all Windows 8/10 package management.<param>
        public WindowsPackageManagerViewModel(IWindowsPackageManager windowsPackageManager)
        {
            _windowsPackageManager = windowsPackageManager;
            UninstallCommand = new RelayCommand<object>((param) => { UninstallPackages(); });
            RetrieveInstalledPackages();
        }

        /// <summary>
        /// Retrieve the installed packages on the user's machine when the application loads.
        /// </summary>
        private async void RetrieveInstalledPackages()
            => Packages = new ObservableCollection<WindowsPackage>(await _windowsPackageManager.GetInstalledPackages().ConfigureAwait(true));

        /// <summary>
        /// Uninstall a collection of packages via the <see cref="IWindowsPackageManager"/>.
        /// </summary>
        private async void UninstallPackages()
        {
            IList<WindowsPackage> packagesToUninstall = Packages.Where(p => p.IsChecked).ToList();

            if (packagesToUninstall.Count == 0)
            {
                MessageBox.Show($"Please select packages to uninstall.");
                return;
            }

            IList<UninstallPackageResponse> uninstallResponses = await _windowsPackageManager.UninstallPackages(packagesToUninstall).ConfigureAwait(false);
            IList<UninstallPackageResponse> uninstallFails = new List<UninstallPackageResponse>();

            foreach (UninstallPackageResponse uninstallResponse in uninstallResponses)
            {
                if (uninstallResponse.Success)
                {
                    packagesToUninstall.Remove(uninstallResponse.Package);
                    Packages.Remove(uninstallResponse.Package);
                }
                else
                    uninstallFails.Add(uninstallResponse);
            }

            if (uninstallFails.Count > 0)
            {
                MessageBox.Show($"The following packages failed to uninstall:{Environment.NewLine}{Environment.NewLine}" +
                    $"{string.Join($"{Environment.NewLine}", uninstallFails.Select(p => $"{p.Package.DisplayName}{Environment.NewLine}\tError: {p.ErrorMessage}{Environment.NewLine}"))}");
            }
        }
    }
}