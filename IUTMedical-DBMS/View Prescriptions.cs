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
    public partial class View_Prescriptions : Form
    {
        Database db = Database.GetInstance();
        public View_Prescriptions()
        {
            InitializeComponent();
            LoadPrescription();
        }
        public void LoadPrescription()
        {

            List<Prescription1> prescription1 = db.GetPrescription();

            dataGridView1.DataSource = prescription1;


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
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

        }
    }
}
