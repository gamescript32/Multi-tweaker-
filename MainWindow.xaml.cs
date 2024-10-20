using System.Windows;
using System.Windows.Controls;

namespace PC_Tweaks_App
{
    public partial class MainWindow : Window
    {
        private readonly ServiceManager serviceManager;

        public MainWindow()
        {
            InitializeComponent();
            serviceManager = new ServiceManager(); // Initialize the ServiceManager

            KeyAuthWindow authWindow = new KeyAuthWindow();
            authWindow.ShowDialog(); // Show the authentication window modally

            if (!authWindow.IsAuthenticated)
            {
                Application.Current.Shutdown(); // Close the application if not authenticated
                return;
            }

            ShowPanel("System"); // Show the default panel if authenticated
        }

        private void ShowPanel(string panelName)
        {
            // Hide all panels
            SystemOptionsPanel.Visibility = Visibility.Collapsed;
            AppsPanel.Visibility = Visibility.Collapsed;
            NetworkPanel.Visibility = Visibility.Collapsed;
            HardwarePanel.Visibility = Visibility.Collapsed;
            CleanerPanel.Visibility = Visibility.Collapsed;
            StartupPanel.Visibility = Visibility.Collapsed;
            OptionsPanel.Visibility = Visibility.Collapsed;

            // Show the selected panel
            switch (panelName)
            {
                case "System":
                    SystemOptionsPanel.Visibility = Visibility.Visible;
                    break;
                case "Apps":
                    AppsPanel.Visibility = Visibility.Visible;
                    break;
                case "Network":
                    NetworkPanel.Visibility = Visibility.Visible;
                    break;
                case "Hardware":
                    HardwarePanel.Visibility = Visibility.Visible;
                    break;
                case "Cleaner":
                    CleanerPanel.Visibility = Visibility.Visible;
                    break;
                case "Startup":
                    StartupPanel.Visibility = Visibility.Visible;
                    break;
                case "Options":
                    OptionsPanel.Visibility = Visibility.Visible;
                    break;
            }
        }

        private async void btnRunCleaner_Click(object sender, RoutedEventArgs e)
        {
            await serviceManager.CleanerService.CleanFortniteTracers(cleanerStatusTextBlock);
        }

        private void LaunchFortnite_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button?.Tag != null)
            {
                string preset = button.Tag.ToString();
                string fortniteArguments = serviceManager.GameLauncherService.GetFortniteArguments(preset);
                serviceManager.GameLauncherService.LaunchGame(@"C:\Path\To\Fortnite\FortniteClient-Win64-Shipping_BE.exe", fortniteArguments, launchStatusTextBlock);
            }
        }

        private void LaunchGTA_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button?.Tag != null)
            {
                string preset = button.Tag.ToString();
                string gtaArguments = serviceManager.GameLauncherService.GetGTAArguments(preset);
                serviceManager.GameLauncherService.LaunchGame(@"D:\SteamLibrary\steamapps\common\Grand Theft Auto V\GTAVLauncher.exe", gtaArguments, launchStatusTextBlock);
            }
        }

        private void btnManageStartup_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Managing startup programs...");
        }

        private void btnCreateRestorePoint_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Creating restore point...");
        }
    }
}