using System.Windows;

namespace Averages
{
  public partial class DialogueWindow : Window
  {
    public DialogueWindow()
    {
      InitializeComponent();
    }

    private void BtnOk_Click(object sender, RoutedEventArgs e)
    {
      DialogResult = true;
    }

    public string GetNumber
    {
      get { return BxInput.Text; }
    }
  }
}
