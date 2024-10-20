using PC_Tweaks_App.Helpers;

namespace PC_Tweaks_App
{
    public class ServiceManager
    {
        public CleanerService CleanerService { get; private set; }
        public GameLauncherService GameLauncherService { get; private set; }

        public ServiceManager()
        {
            CleanerService = new CleanerService();
            GameLauncherService = new GameLauncherService();
        }
    }
}