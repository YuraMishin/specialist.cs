namespace PatientInfo
{
    partial class FrmMain
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
            this.BtnGetPatientInfo = new System.Windows.Forms.Button();
            this.BtnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnGetPatientInfo
            // 
            this.BtnGetPatientInfo.Location = new System.Drawing.Point(89, 104);
            this.BtnGetPatientInfo.Name = "BtnGetPatientInfo";
            this.BtnGetPatientInfo.Size = new System.Drawing.Size(108, 28);
            this.BtnGetPatientInfo.TabIndex = 0;
            this.BtnGetPatientInfo.Text = "Enter Patient Info";
            this.BtnGetPatientInfo.UseVisualStyleBackColor = true;
            this.BtnGetPatientInfo.Click += new System.EventHandler(this.BtnGetPatientInfo_Click);
            // 
            // BtnExit
            // 
            this.BtnExit.Location = new System.Drawing.Point(116, 223);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(67, 23);
            this.BtnExit.TabIndex = 1;
            this.BtnExit.Text = "Exit";
            this.BtnExit.UseVisualStyleBackColor = true;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 262);
            this.Controls.Add(this.BtnExit);
            this.Controls.Add(this.BtnGetPatientInfo);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Form";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnGetPatientInfo;
        private System.Windows.Forms.Button BtnExit;
    }
}

