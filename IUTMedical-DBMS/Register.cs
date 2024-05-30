using Hospital_Management_System;
using Oracle.ManagedDataAccess.Client;
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
    public partial class Register : Form
    {
        Database db = Database.GetInstance();
        public Register()
        {
            InitializeComponent();


        }

        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void uname_tb_TextChanged(object sender, EventArgs e)
        {

        }

        private void pass_tb_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Assuming db is an instance of your Database class that encapsulates Oracle connection and operations
            try
            {
                string email = txt_email.Text;
                string username = txt_username.Text;
                string password = txt_password.Text;
                DateTime dateOfBirth = dateTimePicker1.Value;
                string gender = gender_comboBox1.SelectedItem.ToString();

                db.RegUser(email, username, password, dateOfBirth, gender);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
