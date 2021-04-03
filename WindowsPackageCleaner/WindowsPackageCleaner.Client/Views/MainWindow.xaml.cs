using System.Windows;
using WindowsPackageCleaner.Client.ViewModel;

namespace WindowsPackageCleaner.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initialise an instance of the <see cref="MainWindow"/>.
        /// </summary>
        /// <param name="windowsPackageManagerViewModel">A View-Model implementation to be used in conjunction with the main window.</param>
        public MainWindow(WindowsPackageManagerViewModel windowsPackageManagerViewModel)
        {
            InitializeComponent();
            this.DataContext = windowsPackageManagerViewModel;
        }
    }
}