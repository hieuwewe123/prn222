using System.Net.Http; // For HTTP requests
using System.Windows; // For WPF UI

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Create a single instance of HttpClient for use throughout the app
        private readonly HttpClient client = new HttpClient();

        public MainWindow()
        {
            InitializeComponent(); // Initialize UI components
        }

        // Event handler for the "Close" button
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close(); // Close the application
        }

        // Event handler for the "Clear" button
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtContent.Text = string.Empty; // Clear the HTML content TextBox
        }

        // Event handler for the "View HTML" button
        private async void btnViewHTML_Click(object sender, RoutedEventArgs e)
        {
            string uri = txtURL.Text; // Get the URL from the TextBox

            // Try to fetch the HTML content
            try
            {
                // Send GET request and await the response
                string responseBody = await client.GetStringAsync(uri);

                // Display the response in the content TextBox
                txtContent.Text = responseBody.Trim();
            }
            catch (HttpRequestException ex)
            {
                // Show a MessageBox if an exception occurs
                MessageBox.Show($"Error: {ex.Message}", "HTTP Request Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
