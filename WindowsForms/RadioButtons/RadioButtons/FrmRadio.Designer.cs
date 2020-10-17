namespace RadioButtons
{
    partial class FrmRadio
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRadio));
            this.GrpMood = new System.Windows.Forms.GroupBox();
            this.RbDoSad = new System.Windows.Forms.RadioButton();
            this.RbDoHappy = new System.Windows.Forms.RadioButton();
            this.PicHappy = new System.Windows.Forms.PictureBox();
            this.PicSad = new System.Windows.Forms.PictureBox();
            this.GrpMood.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicHappy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicSad)).BeginInit();
            this.SuspendLayout();
            // 
            // GrpMood
            // 
            this.GrpMood.Controls.Add(this.RbDoSad);
            this.GrpMood.Controls.Add(this.RbDoHappy);
            this.GrpMood.Location = new System.Drawing.Point(35, 27);
            this.GrpMood.Name = "GrpMood";
            this.GrpMood.Size = new System.Drawing.Size(101, 100);
            this.GrpMood.TabIndex = 0;
            this.GrpMood.TabStop = false;
            this.GrpMood.Text = "Moods";
            // 
            // RbDoSad
            // 
            this.RbDoSad.AutoSize = true;
            this.RbDoSad.Location = new System.Drawing.Point(14, 53);
            this.RbDoSad.Name = "RbDoSad";
            this.RbDoSad.Size = new System.Drawing.Size(44, 17);
            this.RbDoSad.TabIndex = 1;
            this.RbDoSad.TabStop = true;
            this.RbDoSad.Text = "Sad";
            this.RbDoSad.UseVisualStyleBackColor = true;
            this.RbDoSad.CheckedChanged += new System.EventHandler(this.RbDoSad_CheckedChanged);
            // 
            // RbDoHappy
            // 
            this.RbDoHappy.AutoSize = true;
            this.RbDoHappy.Location = new System.Drawing.Point(14, 16);
            this.RbDoHappy.Name = "RbDoHappy";
            this.RbDoHappy.Size = new System.Drawing.Size(56, 17);
            this.RbDoHappy.TabIndex = 0;
            this.RbDoHappy.TabStop = true;
            this.RbDoHappy.Text = "Happy";
            this.RbDoHappy.UseVisualStyleBackColor = true;
            this.RbDoHappy.CheckedChanged += new System.EventHandler(this.RbDoHappy_CheckedChanged);
            // 
            // PicHappy
            // 
            this.PicHappy.Image = ((System.Drawing.Image)(resources.GetObject("PicHappy.Image")));
            this.PicHappy.Location = new System.Drawing.Point(169, 32);
            this.PicHappy.Name = "PicHappy";
            this.PicHappy.Size = new System.Drawing.Size(100, 50);
            this.PicHappy.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicHappy.TabIndex = 1;
            this.PicHappy.TabStop = false;
            this.PicHappy.Visible = false;
            // 
            // PicSad
            // 
            this.PicSad.Image = ((System.Drawing.Image)(resources.GetObject("PicSad.Image")));
            this.PicSad.Location = new System.Drawing.Point(168, 109);
            this.PicSad.Name = "PicSad";
            this.PicSad.Size = new System.Drawing.Size(100, 50);
            this.PicSad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicSad.TabIndex = 2;
            this.PicSad.TabStop = false;
            this.PicSad.Visible = false;
            // 
            // FrmRadio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 261);
            this.Controls.Add(this.PicSad);
            this.Controls.Add(this.PicHappy);
            this.Controls.Add(this.GrpMood);
            this.Name = "FrmRadio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Radio Button Example";
            this.GrpMood.ResumeLayout(false);
            this.GrpMood.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicHappy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicSad)).EndInit();
            this.ResumeLayout(false);

        }

    #endregion

    private System.Windows.Forms.GroupBox GrpMood;
    private System.Windows.Forms.RadioButton RbDoSad;
    private System.Windows.Forms.RadioButton RbDoHappy;
    private System.Windows.Forms.PictureBox PicHappy;
    private System.Windows.Forms.PictureBox PicSad;
  }
}

