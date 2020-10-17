using System;
using System.Windows.Forms;

namespace SumGame
{
  public partial class Form1 : Form
  {
    int left, right, result;
    Random r = new Random();

    private void button1_Click(object sender, EventArgs e)
    {
      ValidateAnswer();
    }

    private void ValidateAnswer()
    {
      int answer = Convert.ToInt32(textBox1.Text);
      textBox1.Text = String.Empty;
      if (answer == result)
      {
        ApplyGoodAnswer();
      }
      else
      {
        ApplyWrongAnswer();
      }

      GenerateExpression();
    }

    private void ApplyGoodAnswer()
    {
      progressBar1.Value += 1;
      if (progressBar1.Value == progressBar1.Maximum)
      {
        Close();
      }
    }

    private void ApplyWrongAnswer()
    {
      if (progressBar1.Value == 0)
      {
        Close();
        return;
      }

      progressBar1.Value -= 1;
    }

    private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == (char)Keys.Enter)
      {
        ValidateAnswer();
      }
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      ApplyWrongAnswer();
      GenerateExpression();
    }

    public Form1()
    {
      InitializeComponent();
      GenerateExpression();
    }

    public void GenerateExpression()
    {
      left = r.Next(1, 101);
      right = r.Next(1, 101);
      result = left + right;
      OperandLeft.Text = left.ToString();
      OperandRight.Text = right.ToString();
    }
  }
}
