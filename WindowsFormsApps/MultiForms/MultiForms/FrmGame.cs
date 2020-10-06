using System;
using System.Windows.Forms;

namespace MultiForms
{
  public partial class FrmGame : Form
  {
    public FrmGame()
    {
      InitializeComponent();
    }

    private void BtnReturn_Click(object sender, EventArgs e)
    {
        Close();
    }
  }
}
