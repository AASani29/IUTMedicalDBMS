using IUTMedical_DBMS;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_Management_System
{
        public sealed class Database
    {
        private int loggedInUserId; // Variable to store the logged-in user ID

        public int LoggedInUserId
        {
            get { return loggedInUserId; }
            set { loggedInUserId = value; }
        }

        private Database() { }

        private static Database instance;
        static OracleConnection con = GetDBConnection("localhost", 1521, "XEPDB1", "sani", "sani9999");

        public static Database GetInstance()
        {
            if (instance == null)
            {
                instance = new Database();
            }

            con = GetDBConnection("localhost", 1521, "XEPDB1", "sani", "sani9999");

            return instance;
        }

        public static OracleConnection GetDBConnection(string host, int port, String sid, String user, string password)
        {
            string connString = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=tcp)(HOST=" + host + ")(PORT=" + port + "))(CONNECT_DATA=(SERVICE_NAME=" + sid + ")));User Id=" + user + ";Password=" + password;
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = connString;
            return conn;
        }
        public OracleConnection Connection
        {
            get { return con; }
        }

        public bool RegUser(string email, string username, string password, DateTime dateOfBirth, string gender)
        {
            string insertQuery = "INSERT INTO Users (Username, Password,DateOfBirth, Gender, Email) VALUES (:username, :password,:dob, :gender, :email)";
            try
            {

                con.Open();

                OracleCommand command = new OracleCommand();

                command.CommandText = insertQuery;
                command.Connection = con;


                command.Parameters.Add(":username", OracleDbType.NVarchar2).Value = username;
                command.Parameters.Add(":password", OracleDbType.NVarchar2).Value = password;
                command.Parameters.Add(":dob", OracleDbType.Date).Value = dateOfBirth;
                command.Parameters.Add(":gender", OracleDbType.NVarchar2).Value = gender;
                command.Parameters.Add(":email", OracleDbType.NVarchar2).Value = email;

                int rowsInserted = command.ExecuteNonQuery();

                con.Close();

                if (rowsInserted > 0)
                {
                    MessageBox.Show("Successfully Registered as an User!");

                    return true;

                }

                MessageBox.Show("Failed to register as a User!");

                return false;



            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred(Registration): " + ex.Message);
                con.Close();

                return false;
            }
        }

        public void SaveAppointment(DateTime dateTime, string selectedDoctor, string reason)
        {
            try
            {
                // Get the logged-in user's ID from the loggedInID variable
                int userId = LoggedInUserId;
                int doctorId;


                // Define the insert query
                string insertQuery = "INSERT INTO Appointments (UserID, doctorID, Doctor, DateTime, Reason) VALUES (:userId, :doctorID, :doctor, :dateTime, :reason)";
                if (selectedDoctor == "Dr. Fakhar Zaman")
                {
                    doctorId = 21;
                }
                else if (selectedDoctor == "Dr. Kaniz Fatema")
                {
                    doctorId = 22;
                }
                else
                {
                    // Handle other cases if necessary
                    doctorId = -1; // Default value or throw an exception
                }
                // Open a connection to the database
                using (OracleConnection con = GetDBConnection("localhost", 1521, "XEPDB1", "sani", "sani9999"))
                {
                    con.Open();

                    // Create a command with the insert query
                    using (OracleCommand command = new OracleCommand(insertQuery, con))
                    {

                        // Add parameters to the command
                        command.Parameters.Add(":userId", OracleDbType.Int32).Value = userId;
                        command.Parameters.Add("doctorID", OracleDbType.Int32).Value = doctorId;
                        command.Parameters.Add(":doctor", OracleDbType.Varchar2).Value = selectedDoctor;
                        command.Parameters.Add(":dateTime", OracleDbType.Date).Value = dateTime;
                        command.Parameters.Add(":reason", OracleDbType.Varchar2).Value = reason;

                        // Execute the command to insert the appointment
                        command.ExecuteNonQuery();
                    }
                }

                // Show a success message
                MessageBox.Show("Appointment scheduled successfully!");
            }
            catch (Exception ex)
            {
                // Show an error message if an exception occurs
                MessageBox.Show("An error occurred while saving the appointment: " + ex.Message);
            }
        }




        public List<string> ShowAppointments()
        {
            List<string> appointments = new List<string>();
            try
            {
                con.Open();
                string sql = "SELECT AppointmentID, DateTime, Doctor, Reason FROM Appointments where userid=" + LoggedInUserId;
                OracleCommand command = new OracleCommand(sql, con);
                OracleDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int appointmentID = reader.GetInt32(reader.GetOrdinal("AppointmentID"));
                    DateTime dateTime = reader.GetDateTime(reader.GetOrdinal("DateTime"));
                    string doctor = reader.GetString(reader.GetOrdinal("Doctor"));
                    string reason = reader.GetString(reader.GetOrdinal("Reason"));

                    string appointmentInfo = $"Appointment ID: {appointmentID}, Date and Time: {dateTime}, Doctor: {doctor}, Reason: {reason}";
                    appointments.Add(appointmentInfo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while fetching appointments: {ex.Message}");
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return appointments;
        }

        // Database.cs

        public List<Appointment> GetAppointments()
        {
            List<Appointment> appointments = new List<Appointment>();
            try
            {
                con.Open();
                string sql = "SELECT AppointmentID, DateTime, Doctor, Reason FROM Appointments where userid=" + LoggedInUserId;
                OracleCommand command = new OracleCommand(sql, con);
                OracleDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int appointmentID = reader.GetInt32(reader.GetOrdinal("AppointmentID"));
                    DateTime dateTime = reader.GetDateTime(reader.GetOrdinal("DateTime"));
                    string doctor = reader.GetString(reader.GetOrdinal("Doctor"));
                    string reason = reader.GetString(reader.GetOrdinal("Reason"));

                    Appointment appointment = new Appointment(appointmentID, dateTime, doctor, reason);
                    appointments.Add(appointment);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while fetching appointments: {ex.Message}");
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return appointments;
        }
        public List<Appointment> GetAllAppointments()
        {
            List<Appointment> appointments = new List<Appointment>();
            try
            {
                con.Open();
                string sql = "SELECT AppointmentID, DateTime, Doctor, Reason FROM Appointments where doctorid=" + LoggedInUserId;
                OracleCommand command = new OracleCommand(sql, con);
                OracleDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int appointmentID = reader.GetInt32(reader.GetOrdinal("AppointmentID"));
                    DateTime dateTime = reader.GetDateTime(reader.GetOrdinal("DateTime"));
                    string doctor = reader.GetString(reader.GetOrdinal("Doctor"));
                    string reason = reader.GetString(reader.GetOrdinal("Reason"));

                    Appointment appointment = new Appointment(appointmentID, dateTime, doctor, reason);
                    appointments.Add(appointment);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while fetching appointments: {ex.Message}");
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return appointments;
        }
        public List<Prescription1> GetPrescription()
        {
            List<Prescription1> prescriptions = new List<Prescription1>();
            try
            {
                con.Open();
                string sql = "SELECT PrescriptionId, AppointmentID, Difficulties, MedicineDetails, Tests, FurtherSuggestions FROM Prescription";
                using (OracleCommand command = new OracleCommand(sql, con))
                {
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int prescriptionId = reader.GetInt32(reader.GetOrdinal("PrescriptionId"));
                            int appointmentID = reader.GetInt32(reader.GetOrdinal("AppointmentID"));
                            string difficulties = reader.GetString(reader.GetOrdinal("Difficulties"));
                            string medicineDetails = reader.GetString(reader.GetOrdinal("MedicineDetails"));
                            string tests = reader.GetString(reader.GetOrdinal("Tests"));
                            string furtherSuggestions = reader.GetString(reader.GetOrdinal("FurtherSuggestions"));

                            Prescription1 prescription = new Prescription1(prescriptionId, appointmentID, difficulties, medicineDetails, tests, furtherSuggestions);
                            prescriptions.Add(prescription);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while fetching prescriptions: {ex.Message}");
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return prescriptions;
        }




        public List<string> GetUserNameById()
        {
            List<string> usernames = new List<string>();

            try
            {
                con.Open();
                string sql = "SELECT username FROM users WHERE userid =" + LoggedInUserId;
                OracleCommand command = new OracleCommand(sql, con);


                OracleDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string name = reader.GetString(reader.GetOrdinal("username"));
                    usernames.Add(name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while fetching usernames: {ex.Message}");
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }

            return usernames;
        }
        public decimal GetUserDueAmount()
        {
            decimal dueAmount = 0;

            try
            {
                con.Open();
                string sql = "SELECT Due FROM Users WHERE UserID = :userId";
                OracleCommand command = new OracleCommand(sql, con);
                command.Parameters.Add(":userId", OracleDbType.Int32).Value = LoggedInUserId;

                OracleDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    dueAmount = reader.GetDecimal(reader.GetOrdinal("Due"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while fetching the due amount: {ex.Message}");
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }

            return dueAmount;
        }


        public void SavePrescription(int appointmentId, string difficulties, string medicineDetails, string tests, string furtherSuggestions)
        {
            string insertQuery = "INSERT INTO Prescription (AppointmentID, Difficulties, MedicineDetails, Tests, FurtherSuggestions) VALUES (:appointmentId, :difficulties, :medicineDetails, :tests, :furtherSuggestions)";
            try
            {
                con.Open();

                using (OracleCommand command = new OracleCommand(insertQuery, con))
                {
                    command.Parameters.Add(":appointmentId", OracleDbType.Int32).Value = appointmentId;
                    command.Parameters.Add(":difficulties", OracleDbType.Varchar2).Value = difficulties;
                    command.Parameters.Add(":medicineDetails", OracleDbType.Varchar2).Value = medicineDetails;
                    command.Parameters.Add(":tests", OracleDbType.Varchar2).Value = tests;
                    command.Parameters.Add(":furtherSuggestions", OracleDbType.Varchar2).Value = furtherSuggestions;

                    command.ExecuteNonQuery();
                }

                MessageBox.Show("Prescription saved successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while saving the prescription: " + ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        public void SaveReferRequest(int appointmentId, decimal amount, string referredBy, string reason)
        {
            string insertQuery = "INSERT INTO referRequest (AppointmentID, UserID, Amount, ReferredBy, Reason) VALUES (:appointmentId, :userId, :amount, :referredBy, :reason)";
            try
            {
                con.Open();

                using (OracleCommand command = new OracleCommand(insertQuery, con))
                {
                    command.Parameters.Add(":AppointmentID", OracleDbType.Int32).Value = appointmentId;
                    command.Parameters.Add(":UserID", OracleDbType.Int32).Value = loggedInUserId;
                    command.Parameters.Add(":Amount", OracleDbType.Decimal).Value = amount;
                    command.Parameters.Add(":ReferredBy", OracleDbType.Varchar2).Value = referredBy;
                    command.Parameters.Add(":Reason", OracleDbType.Varchar2).Value = reason;

                    command.ExecuteNonQuery();
                }

                MessageBox.Show("Refer request saved successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while saving the refer request: " + ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }
        public void UpdateUserDue(decimal amount)
        {
            string updateQuery = "UPDATE Users SET Due = Due + :amount WHERE UserID = :userId";
            try
            {
                con.Open();

                using (OracleCommand command = new OracleCommand(updateQuery, con))
                {
                    command.Parameters.Add(":amount", OracleDbType.Decimal).Value = amount;
                    command.Parameters.Add(":userId", OracleDbType.Int32).Value = LoggedInUserId;

                    command.ExecuteNonQuery();
                }

                MessageBox.Show("User due updated successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while updating the user due: " + ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        public List<ReferRequest> GetReferRequests()
        {
            List<ReferRequest> referRequests = new List<ReferRequest>();
            try
            {
                con.Open();
                string sql = "SELECT RequestID, AppointmentID, UserID, Amount, ReferredBy, Reason FROM ReferRequest";
                using (OracleCommand command = new OracleCommand(sql, con))
                {
                    

                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int requestID = reader.GetInt32(reader.GetOrdinal("RequestID"));
                            int appointmentID = reader.GetInt32(reader.GetOrdinal("AppointmentID"));
                            int userID = reader.GetInt32(reader.GetOrdinal("UserID"));
                            decimal amount = reader.GetDecimal(reader.GetOrdinal("Amount"));
                            string referredBy = reader.GetString(reader.GetOrdinal("ReferredBy"));
                            string reason = reader.GetString(reader.GetOrdinal("Reason"));

                            ReferRequest referRequest = new ReferRequest(requestID, appointmentID, userID, amount, referredBy, reason);
                            referRequests.Add(referRequest);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while fetching refer requests: {ex.Message}");
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return referRequests;
        }


        public void LoadDriverInfo()
        {
            try
            {
                con.Open();
                string sql = "select * from Driver";
                OracleCommand oracleCommand = new OracleCommand();

                oracleCommand.CommandText = sql;
                oracleCommand.Connection = con;


                // Fill the DataTable with the results of the SELECT query
                OracleDataReader reader = oracleCommand.ExecuteReader();

                while (reader.Read())
                {
                    //  MessageBox.Show(reader[1].ToString());
                }
                // MessageBox.Show("SUCCESS!");

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); con.Close();
            }
        }

       
    }
}
