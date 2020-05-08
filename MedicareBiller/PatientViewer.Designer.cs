namespace MedicareBiller
{
    partial class PatientViewer
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
            this.dragablePanal = new System.Windows.Forms.Panel();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.btnContinue = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dragablePanal
            // 
            this.dragablePanal.BackColor = System.Drawing.Color.Chocolate;
            this.dragablePanal.Location = new System.Drawing.Point(0, 0);
            this.dragablePanal.Name = "dragablePanal";
            this.dragablePanal.Size = new System.Drawing.Size(700, 34);
            this.dragablePanal.TabIndex = 1;
            this.dragablePanal.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dragablePanal_MouseDown);
            this.dragablePanal.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dragablePanal_MouseMove);
            this.dragablePanal.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dragablePanal_MouseUp);
            // 
            // elementHost1
            // 
            this.elementHost1.Location = new System.Drawing.Point(0, 34);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(700, 350);
            this.elementHost1.TabIndex = 0;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = null;
            // 
            // btnContinue
            // 
            this.btnContinue.Location = new System.Drawing.Point(300, 390);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(122, 59);
            this.btnContinue.TabIndex = 2;
            this.btnContinue.Text = "Continue";
            this.btnContinue.UseVisualStyleBackColor = true;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // PatientViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(700, 461);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.dragablePanal);
            this.Controls.Add(this.elementHost1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PatientViewer";
            this.Text = "PatientViewer";
            this.Load += new System.EventHandler(this.PatientViewer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private System.Windows.Forms.Panel dragablePanal;
        private System.Windows.Forms.Button btnContinue;
    }
}