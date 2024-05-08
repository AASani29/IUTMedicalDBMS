using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IUTMedical_DBMS
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //// Create an instance of the student dashboard form
            //StudentDashboard studentDashboardForm = new StudentDashboard();

            //// Create an instance of the login form
            //Form1 loginForm = new Form1();

            //// Show the login form as a dialog
            //if (loginForm.ShowDialog() == DialogResult.OK) // Assuming DialogResult.OK is set when login is successful
            //{
            //    // If login is successful, hide the login form and show the student dashboard form
            //    loginForm.Hide();
            //    Application.Run(studentDashboardForm);
            //}
            //else
            //{
            //    // Handle the case where login is not successful
            //    // For example, you might want to exit the application or show an error message
            //    Application.Exit(); // Exit the application if login is not successful

            Form1 loginform = new Form1();
            Application.Run(loginform);

            //ScheduleAppointment scheduleAppointmentForm = new ScheduleAppointment();
            //Application.Run(scheduleAppointmentForm);

        }
        }


    }

