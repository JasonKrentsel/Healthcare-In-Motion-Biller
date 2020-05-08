using MedicareBiller.Worker;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedicareBiller
{
    public partial class PatientViewer : Form
    {
        PatientDiscriptor[] patientInfo;

        public PatientViewer(params PatientDiscriptor[] patients)
        {
            patientInfo = patients;
            InitializeComponent();
        }

        private void PatientViewer_Load(object sender, EventArgs e)
        {
            elementHost1.Child = new PatientList(patientInfo);
        }


        // move window
        Point p;
        Boolean mouseDown;
        private void dragablePanal_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void dragablePanal_MouseDown(object sender, MouseEventArgs e)
        {
            p = this.PointToClient(Cursor.Position);
            mouseDown = true;
        }

        private void dragablePanal_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.SetDesktopLocation(Cursor.Position.X - p.X, Cursor.Position.Y - p.Y);
            }
        }
        // move window


        private void btnContinue_Click(object sender, EventArgs e)
        {
            PatientBox[] boxes = ((PatientList)(elementHost1.Child)).boxes;
            List<PatientDiscriptor> goodPatientList = new List<PatientDiscriptor>();
            List<PatientDiscriptor> badPatientList = new List<PatientDiscriptor>();
            foreach (PatientBox box in boxes) {
                if (box.DataIsGood())
                {
                    goodPatientList.Add(box.patientData);
                }
                else {
                    badPatientList.Add(box.patientData);
                }
            }
            Working w = new Working(goodPatientList.ToArray());
            w.Show();
            this.Hide();
        }
    }
}
