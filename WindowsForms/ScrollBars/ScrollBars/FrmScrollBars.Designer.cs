namespace ScrollBars
{
    partial class FrmScrollBars
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
            this.HsbDemo = new System.Windows.Forms.HScrollBar();
            this.LblDemo = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // HsbDemo
            // 
            this.HsbDemo.LargeChange = 1;
            this.HsbDemo.Location = new System.Drawing.Point(41, 75);
            this.HsbDemo.Maximum = 50;
            this.HsbDemo.Name = "HsbDemo";
            this.HsbDemo.Size = new System.Drawing.Size(80, 17);
            this.HsbDemo.TabIndex = 0;
            this.HsbDemo.Scroll += new System.Windows.Forms.ScrollEventHandler(this.HsbDemo_Scroll);
            // 
            // LblDemo
            // 
            this.LblDemo.AutoSize = true;
            this.LblDemo.Location = new System.Drawing.Point(41, 106);
            this.LblDemo.Name = "LblDemo";
            this.LblDemo.Size = new System.Drawing.Size(0, 13);
            this.LblDemo.TabIndex = 1;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(39, 133);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 2;
            // 
            // FrmScrollBars
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 261);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.LblDemo);
            this.Controls.Add(this.HsbDemo);
            this.Name = "FrmScrollBars";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Scroll Bars";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

    #endregion

    private System.Windows.Forms.HScrollBar HsbDemo;
    private System.Windows.Forms.Label LblDemo;
    private System.Windows.Forms.NumericUpDown numericUpDown1;
  }
}

