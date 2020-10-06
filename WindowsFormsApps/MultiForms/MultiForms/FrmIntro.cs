using System;
using System.Windows.Forms;

namespace MultiForms
{
  public partial class FrmIntro : Form
  {
    public FrmIntro()
    {
      InitializeComponent();
    }

    private void BtnWelcome_Click(object sender, EventArgs e)
    {
      var frmGame = new FrmGame();
      frmGame.Show();

    }
  }
}
