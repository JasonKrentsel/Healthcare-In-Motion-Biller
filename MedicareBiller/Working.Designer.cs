namespace MedicareBiller
{
    partial class Working
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Working));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.aLabelWorkingOnIt = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TimerFinishChecker = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MedicareBiller.Properties.Resources.working;
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(-19, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(351, 233);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // aLabelWorkingOnIt
            // 
            this.aLabelWorkingOnIt.AutoSize = true;
            this.aLabelWorkingOnIt.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aLabelWorkingOnIt.ForeColor = System.Drawing.Color.White;
            this.aLabelWorkingOnIt.Location = new System.Drawing.Point(24, 220);
            this.aLabelWorkingOnIt.Name = "aLabelWorkingOnIt";
            this.aLabelWorkingOnIt.Size = new System.Drawing.Size(252, 37);
            this.aLabelWorkingOnIt.TabIndex = 1;
            this.aLabelWorkingOnIt.Text = "We\'re Working on it";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(58, 265);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 26);
            this.label1.TabIndex = 2;
            this.label1.Text = "Closing Chrome will cause errors,\r\nso please don\'t do it";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // TimerFinishChecker
            // 
            this.TimerFinishChecker.Interval = 500;
            this.TimerFinishChecker.Tick += new System.EventHandler(this.TimerFinishChecker_Tick);
            // 
            // Working
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.aLabelWorkingOnIt);
            this.Controls.Add(this.pictureBox1);
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Working";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Working";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label aLabelWorkingOnIt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer TimerFinishChecker;
    }
}