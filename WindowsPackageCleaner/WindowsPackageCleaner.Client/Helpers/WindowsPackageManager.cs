using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Foundation;
using Windows.Management.Deployment;
using WindowsPackageCleaner.Client.Helpers.Interfaces;
using WindowsPackageCleaner.Client.Models;

namespace WindowsPackageCleaner.Client.Helpers
{
    /// <inheritdoc cref="IWindowsPackageManager"/>
    public class WindowsPackageManager : IWindowsPackageManager
    {
        /// <summary>
        /// An instance of <see cref="PackageManager"/> to manage windows packages on the machine in question.
        /// </summary>
        private readonly PackageManager _packageManager;

        /// <summary>
        /// Initialise an instance of <see cref="WindowsPackageManager"/> class.
        /// </summary>
        public WindowsPackageManager() => _packageManager = new PackageManager();

        /// <inheritdoc/>
        public Task<IList<WindowsPackage>> GetInstalledPackages()
        {
            IList<Package> installedPackages = _packageManager
                .FindPackagesForUser(string.Empty)
                .Where(p => !string.IsNullOrEmpty(p.DisplayName))
                .ToList();

            IList<WindowsPackage> installedWindowsPackages = new List<WindowsPackage>();
            installedPackages.ToList().ForEach(p => installedWindowsPackages.Add(
                new WindowsPackage
                {
                    DisplayName = p.DisplayName ?? "Display Name Not Found",
                    Publisher = p.PublisherDisplayName ?? "Publisher Not Found",
                    InstalledDate = p.InstalledDate.ToString("dd/MM/yyyy"),
                    Version = $"{p.Id.Version.Build}.{p.Id.Version.Major}.{p.Id.Version.Minor}"
                }));

            return Task.FromResult(installedWindowsPackages);
        }

        /// <inheritdoc/>
        public Task<IList<UninstallPackageResponse>> UninstallPackages(IEnumerable<WindowsPackage> packages)
        {
            IList<UninstallPackageResponse> uninstallResponses = new List<UninstallPackageResponse>();
            foreach (WindowsPackage package in packages)
            {
                IAsyncOperationWithProgress<DeploymentResult, DeploymentProgress> result
                    = _packageManager.RemovePackageAsync(package.ID.FullName);

                uninstallResponses.Add(new UninstallPackageResponse
                {
                    ErrorMessage = result.ErrorCode?.Message ?? string.Empty,
                    PackageId = package.ID,
                    PackageName = package.DisplayName,
                    Success = string.IsNullOrEmpty(result.ErrorCode?.Message ?? string.Empty)
                });
            }
            return Task.FromResult(uninstallResponses);
        }
    }
}