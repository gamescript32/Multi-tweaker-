using System.Windows;

namespace PC_Tweaks_App
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            KeyAuthWindow keyAuthWindow = new KeyAuthWindow();
            keyAuthWindow.Show();
        }
    }
}