using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUTMedical_DBMS
{
    public class Appointment
    {
        public int AppointmentID { get; set; }
      //  public string PatientName { get; set; }
        public string Doctor { get; set; }
        public DateTime DateTime { get; set; }
        public string Reason { get; set; }


        public Appointment(int appointmentID, DateTime dateTime, string doctor, string reason)
        {
            AppointmentID = appointmentID;
            DateTime = dateTime;
            Doctor = doctor;
            Reason = reason;
        }
    }
}
