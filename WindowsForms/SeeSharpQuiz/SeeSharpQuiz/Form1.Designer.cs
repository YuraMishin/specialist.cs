namespace SeeSharpQuiz
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
            this.lbl_Question1 = new System.Windows.Forms.Label();
            this.lbl_Question2 = new System.Windows.Forms.Label();
            this.lbl_Question3 = new System.Windows.Forms.Label();
            this.lbl_Question5 = new System.Windows.Forms.Label();
            this.lbl_Question4 = new System.Windows.Forms.Label();
            this.Question1_Answer = new System.Windows.Forms.TextBox();
            this.Question2_Answer = new System.Windows.Forms.TextBox();
            this.Question3_Answer = new System.Windows.Forms.TextBox();
            this.Question4_Answer = new System.Windows.Forms.TextBox();
            this.Question5_Answer = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lbl_Feedback = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_Question1
            // 
            this.lbl_Question1.AutoSize = true;
            this.lbl_Question1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Question1.Location = new System.Drawing.Point(13, 13);
            this.lbl_Question1.Name = "lbl_Question1";
            this.lbl_Question1.Size = new System.Drawing.Size(412, 24);
            this.lbl_Question1.TabIndex = 0;
            this.lbl_Question1.Text = "Question 1: All statements must end with a ____.";
            // 
            // lbl_Question2
            // 
            this.lbl_Question2.AutoSize = true;
            this.lbl_Question2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Question2.Location = new System.Drawing.Point(13, 69);
            this.lbl_Question2.Name = "lbl_Question2";
            this.lbl_Question2.Size = new System.Drawing.Size(436, 24);
            this.lbl_Question2.TabIndex = 1;
            this.lbl_Question2.Text = "Question 2: What result is returned by 2 + 3 * 4 / 2 ?";
            // 
            // lbl_Question3
            // 
            this.lbl_Question3.AutoSize = true;
            this.lbl_Question3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Question3.Location = new System.Drawing.Point(13, 125);
            this.lbl_Question3.Name = "lbl_Question3";
            this.lbl_Question3.Size = new System.Drawing.Size(482, 24);
            this.lbl_Question3.TabIndex = 2;
            this.lbl_Question3.Text = "Question 3: What keyword is used to declare an integer?";
            // 
            // lbl_Question5
            // 
            this.lbl_Question5.AutoSize = true;
            this.lbl_Question5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Question5.Location = new System.Drawing.Point(13, 237);
            this.lbl_Question5.Name = "lbl_Question5";
            this.lbl_Question5.Size = new System.Drawing.Size(426, 24);
            this.lbl_Question5.TabIndex = 3;
            this.lbl_Question5.Text = "Question 5: What do double slashes (//) precede?";
            // 
            // lbl_Question4
            // 
            this.lbl_Question4.AutoSize = true;
            this.lbl_Question4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Question4.Location = new System.Drawing.Point(13, 181);
            this.lbl_Question4.Name = "lbl_Question4";
            this.lbl_Question4.Size = new System.Drawing.Size(449, 24);
            this.lbl_Question4.TabIndex = 4;
            this.lbl_Question4.Text = "Question 4: What result is returned by ((3>2)&&(4<2))?";
            // 
            // Question1_Answer
            // 
            this.Question1_Answer.Location = new System.Drawing.Point(17, 41);
            this.Question1_Answer.Name = "Question1_Answer";
            this.Question1_Answer.Size = new System.Drawing.Size(100, 20);
            this.Question1_Answer.TabIndex = 5;
            // 
            // Question2_Answer
            // 
            this.Question2_Answer.Location = new System.Drawing.Point(17, 97);
            this.Question2_Answer.Name = "Question2_Answer";
            this.Question2_Answer.Size = new System.Drawing.Size(100, 20);
            this.Question2_Answer.TabIndex = 6;
            // 
            // Question3_Answer
            // 
            this.Question3_Answer.Location = new System.Drawing.Point(17, 152);
            this.Question3_Answer.Name = "Question3_Answer";
            this.Question3_Answer.Size = new System.Drawing.Size(100, 20);
            this.Question3_Answer.TabIndex = 7;
            // 
            // Question4_Answer
            // 
            this.Question4_Answer.Location = new System.Drawing.Point(17, 209);
            this.Question4_Answer.Name = "Question4_Answer";
            this.Question4_Answer.Size = new System.Drawing.Size(100, 20);
            this.Question4_Answer.TabIndex = 8;
            // 
            // Question5_Answer
            // 
            this.Question5_Answer.Location = new System.Drawing.Point(17, 265);
            this.Question5_Answer.Name = "Question5_Answer";
            this.Question5_Answer.Size = new System.Drawing.Size(100, 20);
            this.Question5_Answer.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(17, 300);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Grade Quiz";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbl_Feedback
            // 
            this.lbl_Feedback.AutoSize = true;
            this.lbl_Feedback.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Feedback.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbl_Feedback.Location = new System.Drawing.Point(13, 336);
            this.lbl_Feedback.Name = "lbl_Feedback";
            this.lbl_Feedback.Size = new System.Drawing.Size(95, 24);
            this.lbl_Feedback.TabIndex = 11;
            this.lbl_Feedback.Text = "Feedback";
            this.lbl_Feedback.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 378);
            this.Controls.Add(this.lbl_Feedback);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Question5_Answer);
            this.Controls.Add(this.Question4_Answer);
            this.Controls.Add(this.Question3_Answer);
            this.Controls.Add(this.Question2_Answer);
            this.Controls.Add(this.Question1_Answer);
            this.Controls.Add(this.lbl_Question4);
            this.Controls.Add(this.lbl_Question5);
            this.Controls.Add(this.lbl_Question3);
            this.Controls.Add(this.lbl_Question2);
            this.Controls.Add(this.lbl_Question1);
            this.Name = "Form1";
            this.Text = "SeeSharp Quiz";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Question1;
        private System.Windows.Forms.Label lbl_Question2;
        private System.Windows.Forms.Label lbl_Question3;
        private System.Windows.Forms.Label lbl_Question5;
        private System.Windows.Forms.Label lbl_Question4;
        private System.Windows.Forms.TextBox Question1_Answer;
        private System.Windows.Forms.TextBox Question2_Answer;
        private System.Windows.Forms.TextBox Question3_Answer;
        private System.Windows.Forms.TextBox Question4_Answer;
        private System.Windows.Forms.TextBox Question5_Answer;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbl_Feedback;
    }
}

