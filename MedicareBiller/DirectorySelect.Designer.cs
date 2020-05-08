namespace MedicareBiller
{
    partial class DirectorySelect
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
            this.aButtonFileSelect = new System.Windows.Forms.Button();
            this.aLabelFileDir = new System.Windows.Forms.Label();
            this.aFileDialogOrderForms = new System.Windows.Forms.OpenFileDialog();
            this.aLabelOrderForms = new System.Windows.Forms.Label();
            this.aLabelDownload = new System.Windows.Forms.Label();
            this.aButtonDownloadFolderDialog = new System.Windows.Forms.Button();
            this.aLabelDownloadFolder = new System.Windows.Forms.Label();
            this.afolderBrowserDownload = new System.Windows.Forms.FolderBrowserDialog();
            this.aLabelOutputHeader = new System.Windows.Forms.Label();
            this.aButtonOutputFolderDialog = new System.Windows.Forms.Button();
            this.afolderBrowserDialogOutput = new System.Windows.Forms.FolderBrowserDialog();
            this.aLabelOutputFolderInfo = new System.Windows.Forms.Label();
            this.aButtonContinue = new System.Windows.Forms.Button();
            this.UpperColorPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.aPictureBoxExit = new System.Windows.Forms.PictureBox();
            this.UpperColorPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aPictureBoxExit)).BeginInit();
            this.SuspendLayout();
            // 
            // aButtonFileSelect
            // 
            this.aButtonFileSelect.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aButtonFileSelect.Location = new System.Drawing.Point(18, 81);
            this.aButtonFileSelect.Name = "aButtonFileSelect";
            this.aButtonFileSelect.Size = new System.Drawing.Size(73, 34);
            this.aButtonFileSelect.TabIndex = 0;
            this.aButtonFileSelect.Text = "Select a File";
            this.aButtonFileSelect.UseVisualStyleBackColor = true;
            this.aButtonFileSelect.Click += new System.EventHandler(this.ButtonFileSelect_Click);
            // 
            // aLabelFileDir
            // 
            this.aLabelFileDir.AutoSize = true;
            this.aLabelFileDir.Location = new System.Drawing.Point(97, 92);
            this.aLabelFileDir.Name = "aLabelFileDir";
            this.aLabelFileDir.Size = new System.Drawing.Size(90, 13);
            this.aLabelFileDir.TabIndex = 1;
            this.aLabelFileDir.Text = "No Files Selected";
            // 
            // aFileDialogOrderForms
            // 
            this.aFileDialogOrderForms.FileName = "openFileDialog1";
            this.aFileDialogOrderForms.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // aLabelOrderForms
            // 
            this.aLabelOrderForms.AutoSize = true;
            this.aLabelOrderForms.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aLabelOrderForms.Location = new System.Drawing.Point(15, 65);
            this.aLabelOrderForms.Name = "aLabelOrderForms";
            this.aLabelOrderForms.Size = new System.Drawing.Size(219, 17);
            this.aLabelOrderForms.TabIndex = 3;
            this.aLabelOrderForms.Text = "Select All the order forms (.pdf files)";
            // 
            // aLabelDownload
            // 
            this.aLabelDownload.AutoSize = true;
            this.aLabelDownload.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.aLabelDownload.Location = new System.Drawing.Point(15, 118);
            this.aLabelDownload.Name = "aLabelDownload";
            this.aLabelDownload.Size = new System.Drawing.Size(329, 17);
            this.aLabelDownload.TabIndex = 4;
            this.aLabelDownload.Text = "Select a Temporary Downloads Folder (must be empty)";
            // 
            // aButtonDownloadFolderDialog
            // 
            this.aButtonDownloadFolderDialog.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold);
            this.aButtonDownloadFolderDialog.Location = new System.Drawing.Point(18, 134);
            this.aButtonDownloadFolderDialog.Name = "aButtonDownloadFolderDialog";
            this.aButtonDownloadFolderDialog.Size = new System.Drawing.Size(73, 34);
            this.aButtonDownloadFolderDialog.TabIndex = 5;
            this.aButtonDownloadFolderDialog.Text = "Select a Folder";
            this.aButtonDownloadFolderDialog.UseVisualStyleBackColor = true;
            this.aButtonDownloadFolderDialog.Click += new System.EventHandler(this.aButtonDownloadFolder_Click);
            // 
            // aLabelDownloadFolder
            // 
            this.aLabelDownloadFolder.AutoSize = true;
            this.aLabelDownloadFolder.Location = new System.Drawing.Point(97, 145);
            this.aLabelDownloadFolder.Name = "aLabelDownloadFolder";
            this.aLabelDownloadFolder.Size = new System.Drawing.Size(98, 13);
            this.aLabelDownloadFolder.TabIndex = 6;
            this.aLabelDownloadFolder.Text = "No Folder Selected";
            // 
            // aLabelOutputHeader
            // 
            this.aLabelOutputHeader.AutoSize = true;
            this.aLabelOutputHeader.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.aLabelOutputHeader.Location = new System.Drawing.Point(15, 171);
            this.aLabelOutputHeader.Name = "aLabelOutputHeader";
            this.aLabelOutputHeader.Size = new System.Drawing.Size(229, 17);
            this.aLabelOutputHeader.TabIndex = 7;
            this.aLabelOutputHeader.Text = "Select a Folder to output the final files";
            // 
            // aButtonOutputFolderDialog
            // 
            this.aButtonOutputFolderDialog.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold);
            this.aButtonOutputFolderDialog.Location = new System.Drawing.Point(18, 187);
            this.aButtonOutputFolderDialog.Name = "aButtonOutputFolderDialog";
            this.aButtonOutputFolderDialog.Size = new System.Drawing.Size(73, 34);
            this.aButtonOutputFolderDialog.TabIndex = 8;
            this.aButtonOutputFolderDialog.Text = "Select a Folder";
            this.aButtonOutputFolderDialog.UseVisualStyleBackColor = true;
            this.aButtonOutputFolderDialog.Click += new System.EventHandler(this.aButtonOutputFolderDialog_Click);
            // 
            // aLabelOutputFolderInfo
            // 
            this.aLabelOutputFolderInfo.AutoSize = true;
            this.aLabelOutputFolderInfo.Location = new System.Drawing.Point(97, 198);
            this.aLabelOutputFolderInfo.Name = "aLabelOutputFolderInfo";
            this.aLabelOutputFolderInfo.Size = new System.Drawing.Size(98, 13);
            this.aLabelOutputFolderInfo.TabIndex = 9;
            this.aLabelOutputFolderInfo.Text = "No Folder Selected";
            // 
            // aButtonContinue
            // 
            this.aButtonContinue.BackColor = System.Drawing.SystemColors.Control;
            this.aButtonContinue.Location = new System.Drawing.Point(168, 252);
            this.aButtonContinue.Name = "aButtonContinue";
            this.aButtonContinue.Size = new System.Drawing.Size(111, 41);
            this.aButtonContinue.TabIndex = 10;
            this.aButtonContinue.Text = "Continue";
            this.aButtonContinue.UseVisualStyleBackColor = false;
            this.aButtonContinue.Click += new System.EventHandler(this.aButtonContinue_Click);
            // 
            // UpperColorPanel
            // 
            this.UpperColorPanel.BackColor = System.Drawing.Color.Chocolate;
            this.UpperColorPanel.Controls.Add(this.label1);
            this.UpperColorPanel.Controls.Add(this.aPictureBoxExit);
            this.UpperColorPanel.Location = new System.Drawing.Point(0, 0);
            this.UpperColorPanel.Name = "UpperColorPanel";
            this.UpperColorPanel.Size = new System.Drawing.Size(438, 34);
            this.UpperColorPanel.TabIndex = 11;
            this.UpperColorPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UpperColorPanel_MouseDown);
            this.UpperColorPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UpperColorPanel_MouseMove);
            this.UpperColorPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.UpperColorPanel_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(361, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select Files and Directories";
            // 
            // aPictureBoxExit
            // 
            this.aPictureBoxExit.BackColor = System.Drawing.Color.Chocolate;
            this.aPictureBoxExit.Image = global::MedicareBiller.Properties.Resources.exit_button1;
            this.aPictureBoxExit.Location = new System.Drawing.Point(408, 0);
            this.aPictureBoxExit.Name = "aPictureBoxExit";
            this.aPictureBoxExit.Size = new System.Drawing.Size(30, 34);
            this.aPictureBoxExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.aPictureBoxExit.TabIndex = 0;
            this.aPictureBoxExit.TabStop = false;
            this.aPictureBoxExit.Click += new System.EventHandler(this.pictureBox1_Click);
            this.aPictureBoxExit.MouseEnter += new System.EventHandler(this.aPictureBoxExit_MouseEnter);
            this.aPictureBoxExit.MouseLeave += new System.EventHandler(this.aPictureBoxExit_MouseLeave);
            // 
            // DirectorySelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(438, 305);
            this.Controls.Add(this.UpperColorPanel);
            this.Controls.Add(this.aButtonContinue);
            this.Controls.Add(this.aLabelOutputFolderInfo);
            this.Controls.Add(this.aButtonOutputFolderDialog);
            this.Controls.Add(this.aLabelOutputHeader);
            this.Controls.Add(this.aLabelDownloadFolder);
            this.Controls.Add(this.aButtonDownloadFolderDialog);
            this.Controls.Add(this.aLabelDownload);
            this.Controls.Add(this.aLabelOrderForms);
            this.Controls.Add(this.aLabelFileDir);
            this.Controls.Add(this.aButtonFileSelect);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DirectorySelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MedicareBiller";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.UpperColorPanel.ResumeLayout(false);
            this.UpperColorPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aPictureBoxExit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button aButtonFileSelect;
        private System.Windows.Forms.Label aLabelFileDir;
        private System.Windows.Forms.OpenFileDialog aFileDialogOrderForms;
        private System.Windows.Forms.Label aLabelOrderForms;
        private System.Windows.Forms.Label aLabelDownload;
        private System.Windows.Forms.Button aButtonDownloadFolderDialog;
        private System.Windows.Forms.Label aLabelDownloadFolder;
        private System.Windows.Forms.FolderBrowserDialog afolderBrowserDownload;
        private System.Windows.Forms.Label aLabelOutputHeader;
        private System.Windows.Forms.Button aButtonOutputFolderDialog;
        private System.Windows.Forms.FolderBrowserDialog afolderBrowserDialogOutput;
        private System.Windows.Forms.Label aLabelOutputFolderInfo;
        private System.Windows.Forms.Button aButtonContinue;
        private System.Windows.Forms.Panel UpperColorPanel;
        private System.Windows.Forms.PictureBox aPictureBoxExit;
        private System.Windows.Forms.Label label1;
    }
}

