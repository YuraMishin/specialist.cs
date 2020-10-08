using System;
using System.Globalization;
using System.Windows;

namespace CurrencyCalc
{
  public partial class MainWindow : Window
  {
    CultureInfo ru;

    public MainWindow()
    {
      InitializeComponent();
      ru = new CultureInfo("ru-RU");
      LblRUB.Content = 0.ToString("c", ru);
    }

    private void BtnConvert_Click(object sender, RoutedEventArgs e)
    {
      var result = Convert.ToInt32(TxtBxUSD.Text) *
                   Convert.ToInt32(TxtBxRate.Text);
      LblRUB.Content = result.ToString("c", ru);
    }
  }
}
