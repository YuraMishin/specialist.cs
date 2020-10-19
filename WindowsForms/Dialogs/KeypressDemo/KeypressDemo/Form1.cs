using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KeypressDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            label1.Text = Convert.ToString(e.KeyChar) + " " + Convert.ToString((int)e.KeyChar);
            textBox1.Text = "";
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //note the use of single quotes for char type data
            if (e.KeyChar < '0' || e.KeyChar > '9')
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }

            //If an unacceptable key is detected, we set 
            //e.Handled to true.  This ‘tricks’ Visual C# Express
            //into thinking the KeyPress event has already been
            //handled and the pressed key is ignored. 
            //If a pressed key is acceptable, we set
            //the e.Handled property to false. 
            //This tells Visual C# Express that this
            //method has not been handled and the
            //KeyPress should be allowed 
            //(by default, e.Handled is false, allowing 
            //all keystrokes).
        }
    }
}