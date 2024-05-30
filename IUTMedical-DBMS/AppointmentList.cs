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

        private void button2_Click(object sender, EventArgs e)
        {
            prescriptionG prescriptiong = new prescriptionG();
            prescriptiong.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
