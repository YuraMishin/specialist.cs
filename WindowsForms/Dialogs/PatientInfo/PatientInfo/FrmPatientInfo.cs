using System;
using System.Windows.Forms;

namespace PatientInfo
{
  public partial class FrmPatientInfo : Form
  {
    public FrmPatientInfo()
    {
      InitializeComponent();
    }

    public string PatientName
    {
      get { return TxtName.Text; }
    }

    public string Address
    {
      get { return TxtAddress.Text; }
    }

    public string City
    {
      get { return TxtCity.Text; }
    }

    public string PostalCode
    {
      get { return TxtPostalCode.Text; }
    }

    public string PhoneNumber
    {
      get { return TxtPhoneNumber.Text; }
    }

    private void TxtPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar < '0' || e.KeyChar > '9')
      {
        e.Handled = true;
      }
      else
      {
        e.Handled = false;
      }
    }

    private void FrmPatientInfo_Load(object sender, EventArgs e)
    {
    }
  }
}
