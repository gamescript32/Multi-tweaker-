using System.Windows;

namespace PC_Tweaks_App
{
    public partial class KeyAuthWindow : Window
    {
        public bool IsAuthenticated { get; private set; } = false;

        public KeyAuthWindow()
        {
            InitializeComponent();
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            string enteredKey = KeyTextBox.Text;

            if (KeyManager.ValidateKey(enteredKey)) // Ensure KeyManager is defined elsewhere
            {
                // Key is valid; proceed to main application
                IsAuthenticated = true;
                this.Close(); // Close the key auth window
            }
            else
            {
                // Invalid key; display error
                StatusTextBlock.Text = "Invalid key. Please try again.";
            }
        }
    }
}
