using Windows.ApplicationModel;

namespace WindowsPackageCleaner.Client.Models
{
    /// <summary>
    /// A simplified version of the <see cref="Package"/> class.
    /// </summary>
    public class WindowsPackage
    {
        /// <summary>
        /// The ID for the package.
        /// </summary>
        public PackageId ID { get; set; }

        /// <summary>
        /// The display name of the package.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The name of the publisher for this package.
        /// </summary>
        public string Publisher { get; set; }

        /// <summary>
        /// The date on which this package was installed or last updated.
        /// </summary>
        public string InstalledDate { get; set; }

        /// <summary>
        /// The current version for this package.
        /// </summary>
        public string Version { get; set; }
    }
}