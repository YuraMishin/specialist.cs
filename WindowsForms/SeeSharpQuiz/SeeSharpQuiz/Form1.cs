using System;
using System.Windows.Forms;

namespace SeeSharpQuiz
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      int Grade = 0;
      String Feedback = "";
      if ((Question1_Answer.Text == ";") ||
          (Question1_Answer.Text == "semicolon"))
      {
        Grade = Grade + 1;
      }

      if ((Question2_Answer.Text == "8"))
      {
        Grade = Grade + 1;
      }

      if ((Question3_Answer.Text == "int"))
      {
        Grade = Grade + 1;
      }

      if ((Question4_Answer.Text == "false"))
      {
        Grade = Grade + 1;
      }

      if ((Question5_Answer.Text == "comment") ||
          (Question5_Answer.Text == "comments"))
      {
        Grade = Grade + 1;
      }

      if (Grade >= 3)
      {
        Feedback = "Well Done!";
      }
      else
      {
        Feedback = "Could do much better!";
      }

      lbl_Feedback.Text = Grade + "/5. " + Feedback;
      lbl_Feedback.Visible = true;
    }

    private void Form1_Load(object sender, EventArgs e)
    {
    }
  }
}
