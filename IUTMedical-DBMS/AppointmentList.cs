using Bus_Reservation_System;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IUTMedical_DBMS
{
    public partial class AppointmentList : Form
    {
        Database db = Database.GetInstance();
        public AppointmentList()
        {
            InitializeComponent();
            LoadAllAppointmentData();
        }
        private void LoadAllAppointmentData()
        {
            List<Appointment> appointments = db.GetAppointments();
            // Add columns manually
            //dataGridView1.Columns.Add("AppointmentID", "Appointment ID");
            //dataGridView1.Columns.Add("DateTime", "Date and Time");
            //dataGridView1.Columns.Add("Doctor", "Doctor");
            //dataGridView1.Columns.Add("Reason", "Reason");

            // Set the data source
            dataGridView1.DataSource = appointments;

        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
