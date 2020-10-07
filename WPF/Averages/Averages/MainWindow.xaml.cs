using System;
using System.Linq;
using System.Windows;

namespace Averages
{
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
    }

    private void BtnAverages_Click(object sender, RoutedEventArgs e)
    {
      int[] numbers = new int[3];
      double averageResult;

      for (int i = 0; i < 3; i++)
      {
        DialogueWindow dialogueWindow = new DialogueWindow();
        var result = dialogueWindow.ShowDialog();
        if (result == true)
        {
          int.TryParse(dialogueWindow.GetNumber, out numbers[i]);
        }
      }

      averageResult = Math.Round((double)numbers.Sum() / 3, 2);
      MessageBox.Show($"Avg = {averageResult}");
    }
  }
}
