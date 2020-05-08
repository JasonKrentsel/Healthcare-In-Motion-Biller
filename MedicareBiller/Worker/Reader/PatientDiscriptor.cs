using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text.pdf;

namespace MedicareBiller.Worker
{
    public class PatientDiscriptor
    {
        public String HICN = "";
        public String surname = "";
        public String name = "";
        public String dateOfBirth = "";
        public String superBill = "";
        public String eligibilityForm = "";
        public String serviceDate = "";
        // pdf document frommedicare
        public enum ElligibiltyState
        {
            NotEligible,
            Medicare,
            HMO,
            NotValid,
            FailedToRead
        }
        public ElligibiltyState elligibiltyState;

        override
        public String ToString()
        {
            return name + "     " + surname + "     " + dateOfBirth + "     " + HICN + "     Service Date: " + serviceDate;
        }
    }
}
