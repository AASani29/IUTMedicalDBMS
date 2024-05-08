using Bus_Reservation_System;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IUTMedical_DBMS
{
    public partial class Form1 : Form
    {
        Database db = Database.GetInstance();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

            db.LoadDriverInfo();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Hide();
            Register RegForm = new Register();
            RegForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Database db = Database.GetInstance();
            OracleConnection connection = db.Connection;
            try
            {
                string enteredUsername = uname_tb.Text;
                string enteredPassword = pass_tb.Text;

                if (enteredUsername == "doctor1" && enteredPassword == "doctor1")
                {
                    db.LoggedInUserId = 21;
                    
                    MessageBox.Show("Login successful as a Doctor!"+db.LoggedInUserId);
                    Doctor_sDashboard doctor_SDashboard = new Doctor_sDashboard();
                    doctor_SDashboard.Show();
                    this.Hide();


                }
                else if(enteredUsername == "doctor2" && enteredPassword == "doctor2")
                {
                    db.LoggedInUserId = 22;

                    MessageBox.Show("Login successful as a Doctor!"+db.LoggedInUserId);
                    Doctor_sDashboard doctor_SDashboard = new Doctor_sDashboard();
                    doctor_SDashboard.Show();
                    this.Hide();

                }
                else
                {

                    // Assuming db is an instance of your Database class that encapsulates Oracle connection and operations
                   

                    // Query the database to retrieve the user record with the entered username
                    string query = "SELECT UserID, Password FROM Users WHERE Username = :Username";
                    OracleCommand command = new OracleCommand(query, connection);
                    command.Parameters.Add(":Username", OracleDbType.NVarchar2).Value = enteredUsername;

                    // Execute the query and retrieve the password and user ID from the database
                    connection.Open();
                    OracleDataReader reader = command.ExecuteReader();


                    if (reader.Read())
                    {
                        string storedPassword = reader.GetString(1);
                        int userId = reader.GetInt32(0); // Retrieve user ID from the database

                        // Compare the entered password with the stored password
                        if (storedPassword != null && storedPassword == enteredPassword)
                        {
                            // Store the user ID in the Database class instance
                            db.LoggedInUserId = userId;

                            MessageBox.Show("Login successful !" + userId);

                            // Proceed with further actions, such as opening a new form or granting access
                            StudentDashboard studentDashboardForm = new StudentDashboard();
                            studentDashboardForm.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Invalid username or password. Please try again.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("User not found. Please check your username.");
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred during login: " + ex.Message);
            }
        

            //if (db.VerifyPass(username,password))
            //{
            //    // Redirect to the next page or show a new form
            //    // For example:
            //    StudentDashboard nextPage = new StudentDashboard();
            //    nextPage.Show();

            //    // Hide current login form if needed
            //    this.Hide();
            //}
            //else
            //{
            //    MessageBox.Show("Invalid username or password. Please try again.");
            //}
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

