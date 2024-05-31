using Hospital_Management_System;
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
    public partial class ViewAppointments : Form
    {
        Database db = Database.GetInstance();
        private void LoadAllAppointmentData()
        {
            List<Appointment> appointments = db.GetAppointmentsAdmin();
            // Add columns manually
            //dataGridView1.Columns.Add("AppointmentID", "Appointment ID");
            //dataGridView1.Columns.Add("DateTime", "Date and Time");
            //dataGridView1.Columns.Add("Doctor", "Doctor");
            //dataGridView1.Columns.Add("Reason", "Reason");

            // Set the data source
            dataGridView1.DataSource = appointments;

        }
        public ViewAppointments()
        {
            InitializeComponent();
            LoadAllAppointmentData();
        }

        private void ViewAppointments_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            AdminDashboard adminDashboard = new AdminDashboard();
            adminDashboard.Show();
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
