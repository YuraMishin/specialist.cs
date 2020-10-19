namespace EvenOdd
{
    partial class FrmEvenOdd
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            this.BtnEvenOdd = new System.Windows.Forms.Button();
            this.BtnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnEvenOdd
            // 
            this.BtnEvenOdd.Location = new System.Drawing.Point(100, 94);
            this.BtnEvenOdd.Name = "BtnEvenOdd";
            this.BtnEvenOdd.Size = new System.Drawing.Size(108, 34);
            this.BtnEvenOdd.TabIndex = 0;
            this.BtnEvenOdd.Text = "Determine Even or Odd";
            this.BtnEvenOdd.UseVisualStyleBackColor = true;
            this.BtnEvenOdd.Click += new System.EventHandler(this.BtnEvenOdd_Click);
            // 
            // BtnExit
            // 
            this.BtnExit.Location = new System.Drawing.Point(125, 191);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(63, 26);
            this.BtnExit.TabIndex = 1;
            this.BtnExit.Text = "Exit";
            this.BtnExit.UseVisualStyleBackColor = true;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // FrmEvenOdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 262);
            this.Controls.Add(this.BtnExit);
            this.Controls.Add(this.BtnEvenOdd);
            this.Name = "FrmEvenOdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Even Odd Problem";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnEvenOdd;
        private System.Windows.Forms.Button BtnExit;
    }
}

