using System;
using System.Windows.Forms;

namespace SimpleDialog
{
  public partial class SimpleDialog : Form
  {
    public SimpleDialog()
    {
      InitializeComponent();
    }

    private void btnInfo_Click(object sender, EventArgs e)
    {
      DialogResult r = MessageBox.Show("Do you understand C#", "Info",
        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
      if (r == DialogResult.Yes)
      {
        MessageBox.Show("You said Yes");
      }
      else if (r == DialogResult.No)
      {
        MessageBox.Show("You said No");
      }
    }

    private void SimpleDialog_Load(object sender, EventArgs e)
    {
    }
  }
}
