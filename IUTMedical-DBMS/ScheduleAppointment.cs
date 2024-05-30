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
    public partial class ScheduleAppointment : Form
    {
        Database db = Database.GetInstance();

        public ScheduleAppointment()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ScheduleAppointment scheduleAppointment = new ScheduleAppointment();
            scheduleAppointment.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            ViewRecords viewRecords = new ViewRecords();
            viewRecords.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Profile profile = new Profile();
            profile.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the logged-in user's ID
                int userId = db.LoggedInUserId;

                // Get the selected date and time
                DateTime selectedDateTime = dateTimePicker1.Value;

                // Get the selected doctor
                string selectedDoctor = comboBox1.SelectedItem.ToString();

                // Determine the doctor ID based on the selected doctor's name
                

                // Get the reason
                string reason = textBox1.Text;

                // Save the appointment to the database
                db.SaveAppointment(selectedDateTime,  selectedDoctor, reason);

                MessageBox.Show("Appointment scheduled successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DueTracker dueTracker = new DueTracker();
            dueTracker  .Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ViewRecords viewRecords1 = new ViewRecords();
            viewRecords1.Show();
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
