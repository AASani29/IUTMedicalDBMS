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

namespace IUTMedical_DBMS
{
    public partial class Profile : Form
    {
        Database db = Database.GetInstance();

        public Profile()
        {
            InitializeComponent();
            LoadUserName();
           
        }
        private void ProfileForm_Load(object sender, EventArgs e)
        {
           
        }
        private void LoadUserName()
        {
            List<String>username = db.GetUserNameById();
            textBox5.Text = username[0];

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

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged_2(object sender, EventArgs e)
        {

        }
    }
}
