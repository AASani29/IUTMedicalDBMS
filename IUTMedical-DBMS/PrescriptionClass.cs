using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUTMedical_DBMS
{
    public class Prescription1
    {
        public int PrescriptionId { get; set; }
        public int AppointmentId { get; set; }
        public string Difficulties { get; set; }
        public string MedicineDetails { get; set; }
        public string Tests { get; set; }
        public string FurtherSuggestions { get; set; }

        // Constructor
        public Prescription1(int prescriptionId, int appointmentId, string difficulties, string medicineDetails, string tests, string furtherSuggestions)
        {
            PrescriptionId = prescriptionId;
            AppointmentId = appointmentId;
            Difficulties = difficulties;
            MedicineDetails = medicineDetails;
            Tests = tests;
            FurtherSuggestions = furtherSuggestions;
        }
       

        // Default constructor
        public Prescription1()
        {
        }
    }

}
