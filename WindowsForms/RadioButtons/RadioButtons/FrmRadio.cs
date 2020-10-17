using System;
using System.Windows.Forms;

namespace RadioButtons
{
  /// <summary>
  /// FrmRadio
  /// </summary>
  public partial class FrmRadio : Form
  {
    /// <summary>
    /// Constructor
    /// </summary>
    public FrmRadio()
    {
      InitializeComponent();
    }

    /// <summary>
    /// Method handles RbDoHappy_CheckedChanged
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="e">EventArgs</param>
    private void RbDoHappy_CheckedChanged(object sender, EventArgs e)
    {
      PicHappy.Visible = true;
      PicSad.Visible = false;
    }

    /// <summary>
    /// Method handles RbDoSad_CheckedChanged
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="e">EventArgs</param>
    private void RbDoSad_CheckedChanged(object sender, EventArgs e)
    {
      PicSad.Visible = true;
      PicHappy.Visible = false;
    }
  }
}
