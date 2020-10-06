using System;
using System.Drawing;
using System.Windows.Forms;

namespace Menus
{
  public partial class FrmMenu : Form
  {
    public FrmMenu()
    {
      InitializeComponent();
    }

    private void redToolStripMenuItem_Click(object sender, EventArgs e)
    {
      BackColor = Color.Red;

    }

    private void greenToolStripMenuItem_Click(object sender, EventArgs e)
    {
      BackColor = Color.Green;
    }

    private void blueToolStripMenuItem_Click(object sender, EventArgs e)
    {
      BackColor = Color.DeepSkyBlue;
    }
  }
}
