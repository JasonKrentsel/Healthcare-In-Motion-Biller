using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MedicareBiller.Worker;
using MedicareBiller.Worker.Reader;

namespace MedicareBiller
{
    public partial class DirectorySelect : Form
    {
        public DirectorySelect()
        {
            InitializeComponent();
            aFileDialogOrderForms.Multiselect = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /*
         * Select Order Forms 
         */
        String[] fileNames;
        Boolean enteredOrderForms;
        private void ButtonFileSelect_Click(object sender, EventArgs e)
        {
            aFileDialogOrderForms.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            String error = "";
            foreach (String n in aFileDialogOrderForms.FileNames) {
                if (n.IndexOf(".pdf") == -1) {
                    error = n;
                    break;
                }
            }
            enteredOrderForms = error == "";
            if (error == "") {
                aLabelFileDir.Text = aFileDialogOrderForms.FileNames.Length + " Forms Selected";
                fileNames = aFileDialogOrderForms.FileNames;
            }
            else {
                aLabelFileDir.Text = "Error: " + error.Substring(error.LastIndexOf("\\")+1) + " is not a pdf";
            }
        }
        /*
         * Select Order Forms 
         */

        /*
         * Select Temp Download Folder
         */
        Boolean enteredDownloadFolder;
        private void aButtonDownloadFolder_Click(object sender, EventArgs e)
        {
            if (afolderBrowserDownload.ShowDialog() == DialogResult.OK) {
                enteredDownloadFolder = IsDirectoryEmpty(afolderBrowserDownload.SelectedPath);
                if (enteredDownloadFolder)
                {
                    GlobalData.downloadLocation = afolderBrowserDownload.SelectedPath;
                    aLabelDownloadFolder.Text = afolderBrowserDownload.SelectedPath;
                }
                else {
                    aLabelDownloadFolder.Text = "Error Path not empty";
                    if (MessageBox.Show("This folder is not empty, would you like to delete all the files inside of it? WARNING: these files won't be recoverable!","Folder Not Empty", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes) {
                        System.IO.DirectoryInfo di = new DirectoryInfo(afolderBrowserDownload.SelectedPath);
                        foreach (FileInfo file in di.GetFiles())
                        {
                            file.Delete();
                        }
                        foreach (DirectoryInfo dir in di.GetDirectories())
                        {
                            dir.Delete(true);
                        }
                        GlobalData.downloadLocation = afolderBrowserDownload.SelectedPath;
                        aLabelDownloadFolder.Text = afolderBrowserDownload.SelectedPath;
                        enteredDownloadFolder = true;
                    }
                }
            }
        }

        public bool IsDirectoryEmpty(string path)
        {
            return !Directory.EnumerateFileSystemEntries(path).Any();
        }

        /*
        * Select Temp Download Folder
        */

        /*
         * Output folder Select
         */
        Boolean enteredOutputFolder;
        private void aButtonOutputFolderDialog_Click(object sender, EventArgs e)
        {
            if (afolderBrowserDialogOutput.ShowDialog() == DialogResult.OK) {
                enteredOutputFolder = true;
                GlobalData.OutputLocation = afolderBrowserDialogOutput.SelectedPath;
                aLabelOutputFolderInfo.Text = afolderBrowserDialogOutput.SelectedPath;
            }
        }
        /*
         * Output folder Select
         */



        private void aButtonContinue_Click(object sender, EventArgs e)
        {
            if (enteredDownloadFolder && enteredOrderForms && enteredOutputFolder)
            {
                //PatientCreator.GetPatientData(fileNames[0]);
                PatientDiscriptor[] patients = new PatientDiscriptor[fileNames.Length];
                for (int x = 0; x < fileNames.Length; x++) {
                    patients[x] = PatientCreator.GetPatientData(fileNames[x]);
                }
                PatientViewer pv = new PatientViewer(patients);
                pv.Show();
                this.Hide();
            }
            else {
                MessageBox.Show("ERROR\n    One or more of the fields have been entered incorrectly or not at all");
            }
        }




        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        Point p;
        Boolean mouseDown;
        private void UpperColorPanel_MouseDown(object sender, MouseEventArgs e)
        {
            p = this.PointToClient(Cursor.Position);
            mouseDown = true;
        }

        private void UpperColorPanel_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void UpperColorPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.SetDesktopLocation(Cursor.Position.X-p.X, Cursor.Position.Y-p.Y);
            }
        }

        private void aPictureBoxExit_MouseEnter(object sender, EventArgs e)
        {
            aPictureBoxExit.BackColor = Color.Tomato;
        }

        private void aPictureBoxExit_MouseLeave(object sender, EventArgs e)
        {
            aPictureBoxExit.BackColor = Color.Chocolate;
        }
    }
}
