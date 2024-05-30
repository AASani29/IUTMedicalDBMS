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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace IUTMedical_DBMS
{
    public partial class DueTracker : Form
    {
        Database db = Database.GetInstance();
        public DueTracker()
        {
            InitializeComponent();
        }

        private void DueTracker_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Profile profile = new Profile();
            profile.Show();
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

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ViewRecords viewRecords = new ViewRecords();
            viewRecords.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ScheduleAppointment scheduleAppointment = new ScheduleAppointment();
            scheduleAppointment.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            View_Prescriptions viewRecords = new View_Prescriptions();
            viewRecords.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox4.Text) ||
              string.IsNullOrWhiteSpace(uname_tb.Text) ||
              string.IsNullOrWhiteSpace(textBox1.Text) ||
              string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            int appointmentId = db.LoggedInUserId;

            decimal amount;
            if (!decimal.TryParse(uname_tb.Text, out amount))
            {
                MessageBox.Show("Invalid amount.");
                return;
            }

            
            string referredBy = textBox1.Text;
            string reason = textBox3.Text;

            db.SaveReferRequest(appointmentId, amount, referredBy, reason);
            db.UpdateUserDue(amount);

           
            

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }
    }
}
