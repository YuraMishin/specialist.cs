using System;
using System.Windows.Forms;

namespace FirstApp
{
  /// <summary>
  /// Class FrmFirstApp
  /// </summary>
  public partial class FrmFirstApp : Form
  {
    /// <summary>
    /// Constructor
    /// </summary>
    public FrmFirstApp()
    {
      InitializeComponent();
    }

    /// <summary>
    /// Method handles BtnWelcome click
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="e">EventArgs</param>
    private void BtnWelcome_Click(object sender, EventArgs e)
    {
      MessageBox.Show("Welcome");
    }

    /// <summary>
    /// Method handles BtnExit click
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="e">EventArgs</param>
    private void BtnExit_Click(object sender, EventArgs e)
    {
      Close();
    }
  }
}
