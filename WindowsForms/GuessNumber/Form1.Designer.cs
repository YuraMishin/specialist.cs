namespace GuessNumber
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.nudGuess = new System.Windows.Forms.NumericUpDown();
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnPick = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudGuess)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMessage
            // 
            this.txtMessage.BackColor = System.Drawing.Color.White;
            this.txtMessage.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMessage.ForeColor = System.Drawing.Color.Blue;
            this.txtMessage.Location = new System.Drawing.Point(13, 12);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ReadOnly = true;
            this.txtMessage.Size = new System.Drawing.Size(269, 110);
            this.txtMessage.TabIndex = 0;
            this.txtMessage.TabStop = false;
            this.txtMessage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // nudGuess
            // 
            this.nudGuess.BackColor = System.Drawing.Color.White;
            this.nudGuess.Enabled = false;
            this.nudGuess.Font = new System.Drawing.Font("Arial", 15.75F);
            this.nudGuess.ForeColor = System.Drawing.Color.Red;
            this.nudGuess.Location = new System.Drawing.Point(88, 129);
            this.nudGuess.Name = "nudGuess";
            this.nudGuess.ReadOnly = true;
            this.nudGuess.Size = new System.Drawing.Size(120, 32);
            this.nudGuess.TabIndex = 1;
            this.nudGuess.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudGuess.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // btnCheck
            // 
            this.btnCheck.Enabled = false;
            this.btnCheck.Location = new System.Drawing.Point(103, 165);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(94, 22);
            this.btnCheck.TabIndex = 2;
            this.btnCheck.Text = "Check Guess";
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // btnPick
            // 
            this.btnPick.Location = new System.Drawing.Point(13, 196);
            this.btnPick.Name = "btnPick";
            this.btnPick.Size = new System.Drawing.Size(94, 22);
            this.btnPick.TabIndex = 3;
            this.btnPick.Text = "Pick Number";
            this.btnPick.Click += new System.EventHandler(this.btnPick_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(191, 194);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(94, 22);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(297, 224);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnPick);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.nudGuess);
            this.Controls.Add(this.txtMessage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Guess the Number";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudGuess)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.NumericUpDown nudGuess;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Button btnPick;
        private System.Windows.Forms.Button btnExit;
    }
}

