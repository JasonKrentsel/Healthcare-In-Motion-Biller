using iTextSharp.text;
using iTextSharp.text.pdf;
using MedicareBiller.Worker;
using MedicareBiller.Worker.Driving;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedicareBiller
{
    public partial class Working : Form
    {
        Thread t;
        PatientDiscriptor[] patientList;

        public Working(params PatientDiscriptor[] patients)
        {
            InitializeComponent();
            patientList = patients;
            WebWorker ww = new WebWorker(patients);
            t = new Thread(new ThreadStart(ww.work));
            t.Start();
        }

        private void TimerFinishChecker_Tick(object sender, EventArgs e)
        {
            if (!t.IsAlive) {
                Application.Exit();
            }
        }
    }
}
