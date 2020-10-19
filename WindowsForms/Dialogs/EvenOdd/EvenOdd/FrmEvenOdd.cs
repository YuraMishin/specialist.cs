using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EvenOdd
{
    public partial class FrmEvenOdd : Form
    {
        public FrmEvenOdd()
        {
            InitializeComponent();
        }

        private void BtnEvenOdd_Click(object sender, EventArgs e)
        {
            InputBox input = new InputBox();
            DialogResult result;
            string message;
            int num;

            do
            {
                result=input.ShowDialog();                    

                if (result==DialogResult.OK)
                {
                    
                    //this uses get from the InputValue property
                    num = int.Parse(input.InputValue);
                    if (num%2 ==0)
                    {
                        message="Even";
                    }
                    else
                    {
                        message="Odd";
                    }

                    MessageBox.Show(message,"Message", MessageBoxButtons.OK,MessageBoxIcon.Information);

                    result = MessageBox.Show("Do Another?", "Continue?",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

                    //this uses set from the InputValue property
                    input.InputValue = "";
                }
            }
            while (result==DialogResult.Yes);
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}