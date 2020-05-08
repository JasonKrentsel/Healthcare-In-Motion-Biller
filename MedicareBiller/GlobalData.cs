using MedicareBiller.Worker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicareBiller
{
    class GlobalData
    {
        public static String downloadLocation;
        public static String OutputLocation;
        public static String username = "p.romero@coastalmobilexray.com";
        public static String password = "Portable1";
        public static PatientDiscriptor[] badPatients;
        public static Boolean doneWorking = false;
    }
}
