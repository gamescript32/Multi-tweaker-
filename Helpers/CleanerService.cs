using System;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PC_Tweaks_App.Helpers
{
    public class CleanerService
    {
        private string fortnitePath = @"C:\Users\[Your Username]\AppData\Local\FortniteGame\Saved\"; // Update with actual username

        public async Task CleanFortniteTracers(TextBlock statusTextBlock)
        {
            try
            {
                var traceFiles = Directory.GetFiles(fortnitePath, "*.tmp")
                                           .Concat(Directory.GetFiles(fortnitePath, "*.log"))
                                           .ToList();

                if (!traceFiles.Any())
                {
                    statusTextBlock.Text = "No trace files found.";
                    return;
                }

                var result = MessageBox.Show($"Are you sure you want to delete {traceFiles.Count} trace files?",
                                             "Confirm Deletion",
                                             MessageBoxButton.YesNo,
                                             MessageBoxImage.Warning);

                if (result == MessageBoxResult.No)
                    return;

                var deletedFiles = new ConcurrentBag<string>();

                await Task.Run(() =>
                {
                    Parallel.ForEach(traceFiles, file =>
                    {
                        try
                        {
                            File.Delete(file);
                            deletedFiles.Add(file);
                        }
                        catch (Exception ex)
                        {
                            Application.Current.Dispatcher.Invoke(() =>
                                MessageBox.Show($"Error deleting file {file}: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error));
                        }
                    });
                });

                foreach (var file in deletedFiles)
                {
                    statusTextBlock.Text += $"Deleted: {file}\n";
                    LogDeletedFile(file);
                }

                MessageBox.Show("Cleaning completed!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LogDeletedFile(string filePath)
        {
            File.AppendAllText("deleted_files_log.txt", $"{DateTime.Now}: Deleted {filePath}\n");
        }
    }
}