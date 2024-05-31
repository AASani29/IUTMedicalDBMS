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
    public partial class prescriptionG : Form
    {
        Database db = Database.GetInstance();
        public prescriptionG()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void prescriptionG_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Symptoms.Text) ||
               string.IsNullOrWhiteSpace(textBox6.Text) ||
               string.IsNullOrWhiteSpace(textBox7.Text) ||
               string.IsNullOrWhiteSpace(textBox5.Text) )
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            int appointmentId = db.LoggedInUserId;
           

            string difficulties = Symptoms.Text;
            string medicineDetails = textBox6.Text;
            string tests = textBox7.Text;
            string furtherSuggestions = textBox5.Text;

            db.SavePrescription(appointmentId, difficulties, medicineDetails, tests, furtherSuggestions);

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            DoctorProfile doctorProfile = new DoctorProfile();  
            doctorProfile.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
