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
using static Bus_Reservation_System.Database;

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

        //    Appointment appointment = db.GetAppointment(appointmentID);

        //    void LoadAppointmentInfo()
        //    {
        //        Appointment appointment = db.GetAppointment(appointmentID);
        //        if (appointment != null)
        //        {
        //            ShowAppointmentDetails(appointment);
        //        }
        //        else
        //        {
        //            ShowNoAppointmentsMessage();
        //        }
        //    }
        //    private void ShowAppointmentDetails(Appointment appointment)
        //    {
        //        uname_tb.Text = appointment.PatientName;
        //        docNamedb.Text = appointment.Doctor;
        //        timeTb.Text = appointment.DateTime.ToString();
        //        reasontb.Text = appointment.Reason;
        //    }
        //}

        //private void ShowNoAppointmentsMessage()
        //{
        //    MessageBox.Show("No appointments found.");
        //}

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
    }
}


