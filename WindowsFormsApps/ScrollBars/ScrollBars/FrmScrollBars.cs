using System.Windows.Forms;

namespace ScrollBars
{
  public partial class FrmScrollBars : Form
  {
    public FrmScrollBars()
    {
      InitializeComponent();
    }

    private void HsbDemo_Scroll(object sender, ScrollEventArgs e)
    {
      LblDemo.Text = HsbDemo.Value.ToString();
    }
  }
}
