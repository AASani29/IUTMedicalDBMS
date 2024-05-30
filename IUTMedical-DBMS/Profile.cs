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
    public partial class Profile : Form
    {
        Database db = Database.GetInstance();

       
        public Profile()
        {
            InitializeComponent();
            LoadUserName();
            Loadamount();
        }
        private void ProfileForm_Load(object sender, EventArgs e)
        {

        }
        private void LoadUserName()
        {
            List<String> username = db.GetUserNameById();
            textBox5.Text = username[0];

        }
        private void Loadamount()
        {
            decimal amount = db.GetUserDueAmount();
            textBox6.Text = amount.ToString();
        }




        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox5_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged_2(object sender, EventArgs e)
        {

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

        private void button3_Click(object sender, EventArgs e)
        {
            DueTracker dueTracker = new DueTracker();
            dueTracker.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            View_Prescriptions viewRecords = new View_Prescriptions();
            viewRecords.Show();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
