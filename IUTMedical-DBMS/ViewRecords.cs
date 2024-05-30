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
using static Hospital_Management_System.Database;

namespace IUTMedical_DBMS
{
    public partial class ViewRecords : Form
    {
        Database db = Database.GetInstance();


        public ViewRecords()
        {
            InitializeComponent();
            LoadAppointmentData();
        }
        private void LoadAppointmentData()
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

        

        private void label1_Click(object sender, EventArgs e)
        {
            // Event handler for label click
        }





        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DueTracker dueTracker = new DueTracker();
            dueTracker.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ScheduleAppointment scheduleAppointment = new ScheduleAppointment();
            scheduleAppointment.Show();
            this.Hide();
        }

        private void uname_tb_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void ViewRecords_Load(object sender, EventArgs e)
        {


        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ViewRecords viewRecords = new ViewRecords();
            viewRecords.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Profile profile = new Profile();
            profile.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            View_Prescriptions viewRecords = new View_Prescriptions();
            viewRecords.Show();
        }
    }
}


