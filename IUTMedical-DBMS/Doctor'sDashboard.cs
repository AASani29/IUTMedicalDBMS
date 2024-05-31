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
    public partial class Doctor_sDashboard : Form
    {
        public Doctor_sDashboard()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AppointmentList appointmentList = new AppointmentList();
            appointmentList.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DoctorProfile doctorProfile = new DoctorProfile();
            doctorProfile.Show();
            this.Close();
        }
    }
}
