using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MedicareBiller.Worker;

namespace MedicareBiller
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new DirectorySelect());

            PatientDiscriptor patient = new PatientDiscriptor();
            patient.name = "Jason";
            patient.surname = "Krentsel";
            patient.dateOfBirth = "birthday";
            patient.HICN = "1234567890";

            Application.Run(new DirectorySelect());
            //Application.Run(new PatientViewer(patient));
        }
    }
}
