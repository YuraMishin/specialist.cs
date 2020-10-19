#region Using directives

using System;
using System.Windows.Forms;

#endregion

namespace GuessNumber
{
  partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    int theNumber;
    int myGuess;
    Random myRandom = new Random();

    private void btnPick_Click(object sender, EventArgs e)
    {
      if (btnPick.Text == "Pick Number")
      {
        // Get new number and set controls
        theNumber = myRandom.Next(101);
        txtMessage.Text = "I'm thinking of a number between 0 and 100";
        nudGuess.Value = 50;
        nudGuess.Enabled = true;
        btnCheck.Enabled = true;
        btnPick.Text = "Show Answer";
      }
      else
      {
        // Just show the answer and re-set controls
        txtMessage.Text = "The answer is" + Convert.ToString(theNumber);
        nudGuess.Value = theNumber;
        nudGuess.Enabled = false;
        btnCheck.Enabled = false;
        btnPick.Text = "Pick Number";
      }
    }

    private void btnCheck_Click(object sender, EventArgs e)
    {
      // Guess is the updown control value
      myGuess = (int) nudGuess.Value;
      if (myGuess == theNumber)
      {
        // Correct guess
        txtMessage.Text = "That's it!!";
        nudGuess.Enabled = false;
        btnCheck.Enabled = false;
        btnPick.Text = "Pick Number";
      }
      else if (myGuess < theNumber)
      {
        // Guess is too low
        txtMessage.Text = "Too low!";
      }
      else
      {
        // Guess is too high
        txtMessage.Text = "Too high!";
      }
    }

    private void btnExit_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
    }
  }
}
