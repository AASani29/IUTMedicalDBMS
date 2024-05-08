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
    public partial class StudentDashboard : Form
    {
        public StudentDashboard()
        {
            InitializeComponent();
        }

        private void StudentDashboard_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Profile profile = new Profile();
            profile.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ScheduleAppointment scheduleAppointment = new ScheduleAppointment();
            scheduleAppointment.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            DueTracker dueTracker = new DueTracker();
            dueTracker.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ViewRecords viewRecords = new ViewRecords();
            viewRecords.Show();
            this.Hide();
        }
    }
}
