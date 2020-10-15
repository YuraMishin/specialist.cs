using System;
using System.Windows.Forms;

namespace Pizza
{
    public partial class FrmPizza : Form
    {
        public FrmPizza()
        {
            InitializeComponent();
        }

        double small, medium, large, xlarge;
        double basic, veggie, meatlovers, stuffedcrust, deluxe;
        double baseprice, basicsurcharge, subtotal, tax, total, grandtotal;

        private void Form1_Load(object sender, EventArgs e)
        {
            small = 4.99;
            medium = 5.99;
            large = 7.99;
            xlarge = 9.99;
            basic = 0.89;
            veggie = 1.49;
            meatlovers = 2.07;
            stuffedcrust = 3.45;
            deluxe = 4.75;

            baseprice = 0;
            basicsurcharge = 0;

            TxtQuantity.Text = "0";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            baseprice = small;
            total = baseprice + basicsurcharge;

            TxtBasePrice.Text = baseprice.ToString("c");
            TxtPrice.Text = total.ToString("c");
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            baseprice = medium;
            total = baseprice + basicsurcharge;

            TxtBasePrice.Text = baseprice.ToString("c");
            TxtPrice.Text = total.ToString("c");
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            baseprice = large;
            total = baseprice + basicsurcharge;

            TxtBasePrice.Text = baseprice.ToString("c");
            TxtPrice.Text = total.ToString("c");
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            baseprice = xlarge;
            total = baseprice + basicsurcharge;

            TxtBasePrice.Text = baseprice.ToString("c");
            TxtPrice.Text = total.ToString("c");
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            basicsurcharge = basic;
            total = baseprice + basicsurcharge;

            TxtItemSurcharge.Text = basicsurcharge.ToString("c");
            TxtPrice.Text = total.ToString("c");
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            basicsurcharge = veggie;
            total = baseprice + basicsurcharge;

            TxtItemSurcharge.Text = basicsurcharge.ToString("c");
            TxtPrice.Text = total.ToString("c");
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            basicsurcharge = meatlovers;
            total = baseprice + basicsurcharge;

            TxtItemSurcharge.Text = basicsurcharge.ToString("c");
            TxtPrice.Text = total.ToString("c");
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            basicsurcharge = stuffedcrust;
            total = baseprice + basicsurcharge;

            TxtItemSurcharge.Text = basicsurcharge.ToString("c");
            TxtPrice.Text = total.ToString("c");
        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            basicsurcharge = deluxe;
            total = baseprice + basicsurcharge;

            TxtItemSurcharge.Text = basicsurcharge.ToString("c");
            TxtPrice.Text = total.ToString("c");
        }

        private void BtnCalculate_Click(object sender, EventArgs e)
        {
            subtotal = total * int.Parse(TxtQuantity.Text);
            TxtSubTotal.Text = subtotal.ToString("c");

            tax = subtotal * 0.14;
            TxtTax.Text = tax.ToString("c");

            grandtotal = subtotal + tax;
            TxtTotal.Text = grandtotal.ToString("c");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;
            radioButton7.Checked = false;
            radioButton8.Checked = false;
            radioButton9.Checked = false;

            baseprice = 0;
            basicsurcharge = 0;
            TxtBasePrice.Text = "";
            TxtItemSurcharge.Text = "";
            TxtPrice.Text = "";
            TxtQuantity.Text = "";
            TxtSubTotal.Text = "";
            TxtTax.Text = "";
            TxtTotal.Text = "";
            TxtQuantity.Text = "0";
        }
    }
}