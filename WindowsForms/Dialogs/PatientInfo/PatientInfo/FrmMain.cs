using System;
using System.Windows.Forms;

namespace PatientInfo
{
  public partial class FrmMain : Form
  {
    public FrmMain()
    {
      InitializeComponent();
    }

    private void BtnGetPatientInfo_Click(object sender, EventArgs e)
    {
      FrmPatientInfo p = new FrmPatientInfo();
      if (p.ShowDialog() == DialogResult.OK)
      {
        MessageBox.Show(p.PatientName + "\n" + p.Address + "\n" + p.City +
                        "\n" + p.PostalCode + "\n" + p.PhoneNumber);
      }
    }

    private void BtnExit_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void FrmMain_Load(object sender, EventArgs e)
    {
    }
  }
}
