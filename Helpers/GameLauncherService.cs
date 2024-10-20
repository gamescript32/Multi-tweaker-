using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace PC_Tweaks_App.Helpers
{
    public class GameLauncherService
    {
        public void LaunchGame(string gamePath, string arguments, TextBlock statusTextBlock)
        {
            if (!File.Exists(gamePath))
            {
                MessageBox.Show("Game executable not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                Process.Start(gamePath, arguments);
                statusTextBlock.Text = "Launching game...";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error launching game: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public string GetFortniteArguments(string preset)
        {
            switch (preset)
            {
                case "low":
                    return "-quality low";
                case "medium":
                    return "-quality medium";
                case "ultra":
                    return "-quality epic";
                default:
                    return "";
            }
        }

        public string GetGTAArguments(string preset)
        {
            switch (preset)
            {
                case "low":
                    return "-quality low";
                case "medium":
                    return "-quality medium";
                case "ultra":
                    return "-quality high"; // Adjust as needed
                default:
                    return "";
            }
        }
    }
}