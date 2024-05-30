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
    public partial class AdminDashboard : Form
    {
        Database db = Database.GetInstance();


        public void LoadReferRequests()
        {
            List<ReferRequest> Refers = db.GetReferRequests();


            // Set the data source
            dataGridView1.DataSource = Refers;
        }
        
        public AdminDashboard()
        {
            InitializeComponent();
            LoadReferRequests();
        }
        

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
