using System;
using System.Windows;

namespace WpfApplication
{
    /// <summary>
    /// WPF application to read and format data
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Constructor for MainWindow
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Read a line of data entered by the user.
        /// Format the data and display the results in the
        /// formattedText TextBlock control.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void testButton_Click(object sender, RoutedEventArgs e)
        {
            string line = testInput.Text;
            line = line.Replace(",", " y:");
            line = "x:" + line;
            formattedText.Text = line;
        }
        /// <summary>
        /// After the Window has loaded, read data from the standard input.
        /// Format each line and display the results in the
        /// formattedText TextBlock control.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string line;
            while ((line = Console.ReadLine()) != null)
            {
                line = line.Replace(",", " y:");
                line = "x:" + line + "\n";
                formattedText.Text += line;
            }
        }
    }
}
