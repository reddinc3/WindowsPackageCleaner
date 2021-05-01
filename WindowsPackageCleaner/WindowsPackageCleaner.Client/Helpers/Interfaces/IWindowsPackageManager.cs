using System.Collections.Generic;
using System.Threading.Tasks;
using WindowsPackageCleaner.Client.Models;

namespace WindowsPackageCleaner.Client.Helpers.Interfaces
{
    /// <summary>
    /// Provides functionality to allow one to manage windows packages on one's PC.
    /// </summary>
    public interface IWindowsPackageManager
    {
        /// <summary>
        /// Retrieves a collection of installed Windows 10 packages for the current user.
        /// </summary>
        /// <returns>An <see cref="IList{T}"/> of the Windows 10 packages currently installed on the user's machine.</returns>
        Task<IList<WindowsPackage>> GetInstalledPackages();

        /// <summary>
        /// Attempts to uninstall a collection of Windows packages.
        /// </summary>
        /// <param name="packages">The packages to be uninstalled.</param>
        /// <returns>An <see cref="IList{T}"/> of response objects denoting whether or not each uninstallation succeeded.</returns>
        Task<IList<UninstallPackageResponse>> UninstallPackages(IList<WindowsPackage> packages);
    }
}