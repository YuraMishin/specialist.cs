using System;
using System.Windows.Forms;

namespace SJBcafe
{
  public partial class FrmSJBcafe : Form
  {
    public FrmSJBcafe()
    {
      InitializeComponent();
    }

    double soup, salad, chicken, lasagna, steak, pop, water, juice;
    double appetizer, main, refreshment, subtotal, tax, total;


    private void BtnExit_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void FrmSJBcafe_Load(object sender, EventArgs e)
    {
      soup = 2.00;
      salad = 2.50;
      chicken = 10.50;
      lasagna = 11.75;
      steak = 15.00;
      pop = 1.25;
      water = 1.00;
      juice = 1.30;


      appetizer = 0;
      main = 0;
      refreshment = 0;
      subtotal = 0;
      tax = 0;
      total = 0;
    }

    private void BtnNewOrder_Click(object sender, EventArgs e)
    {
      RdoApp1.Checked = false;
      RdoApp2.Checked = false;
      RdoMain1.Checked = false;
      RdoMain2.Checked = false;
      RdoMain3.Checked = false;
      RdoRefreshment1.Checked = false;
      RdoRefreshment2.Checked = false;
      RdoRefreshment3.Checked = false;

      TxtAppetizer.Text = "";
      TxtMain.Text = "";
      TxtRefreshment.Text = "";
      TxtSubtotal.Text = "";
      TxtTax.Text = "";
      TxtTotal.Text = "";

      appetizer = 0;
      main = 0;
      refreshment = 0;
      subtotal = 0;
      tax = 0;
      total = 0;
    }

    private void RdoApp1_CheckedChanged(object sender, EventArgs e)
    {
      TxtAppetizer.Text = soup.ToString("c");
      appetizer = soup;
    }

    private void RdoApp2_CheckedChanged(object sender, EventArgs e)
    {
      TxtAppetizer.Text = salad.ToString("c");
      appetizer = salad;
    }

    private void RdoMain1_CheckedChanged(object sender, EventArgs e)
    {
      TxtMain.Text = chicken.ToString("c");
      main = chicken;
    }

    private void RdoMain2_CheckedChanged(object sender, EventArgs e)
    {
      TxtMain.Text = lasagna.ToString("c");
      main = lasagna;
    }

    private void RdoMain3_CheckedChanged(object sender, EventArgs e)
    {
      TxtMain.Text = steak.ToString("c");
      main = steak;
    }

    private void RdoRefreshment1_CheckedChanged(object sender, EventArgs e)
    {
      TxtRefreshment.Text = pop.ToString("c");
      refreshment = pop;
    }

    private void RdoRefreshment2_CheckedChanged(object sender, EventArgs e)
    {
      TxtRefreshment.Text = water.ToString("c");
      refreshment = water;
    }

    private void RdoRefreshment3_CheckedChanged(object sender, EventArgs e)
    {
      TxtRefreshment.Text = juice.ToString("c");
      refreshment = juice;
    }

    private void BtnCalculate_Click(object sender, EventArgs e)
    {
      subtotal = appetizer + main + refreshment;
      tax = subtotal * .13;
      total = subtotal + tax;

      TxtSubtotal.Text = subtotal.ToString("c");
      TxtTax.Text = tax.ToString("c");
      TxtTotal.Text = total.ToString("c");
    }
  }
}
