using Windows.ApplicationModel;

namespace WindowsPackageCleaner.Client.Models
{
    /// <summary>
    /// Represents a single response to a request to uninstall a Windows package.
    /// </summary>
    public class UninstallPackageResponse
    {
        /// <summary>
        /// The error message provided, in the event that the uninstallation fails.
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// The ID of the package being uninstalled.
        /// </summary>
        public PackageId PackageId { get; set; }

        /// <summary>
        /// The name of the package being uninstalled.
        /// </summary>
        public string PackageName { get; set; }

        /// <summary>
        /// Whether or not the uninstallation succeeded.
        /// </summary>
        public bool Success { get; set; }
    }
}