using System.Text;
using System.Windows;

namespace IntegerToBinary
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Constructor for Main Window
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Convert an integer to binary
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConvertButton_Click(object sender, RoutedEventArgs e)
        {
            int userInput;
            if (!int.TryParse(inputTextBox.Text, out userInput))
            {
                MessageBox.Show("Textbox does not contain an integer");
                return;
            }

            if (userInput < 0)
            {
                MessageBox.Show("Please enter a positive number or zero");
                return;
            }

            int reminder;
            var result = new StringBuilder();
            do
            {
                reminder = userInput % 2;
                userInput /= 2;
                result.Insert(0, reminder);

            } while (userInput > 0);

            binaryLabel.Content = result.ToString();
        }
    }
}
