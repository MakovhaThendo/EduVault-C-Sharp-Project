using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EduVault
{
    public partial class PaswordReset : Form
    {
        //Get database location
        string dbPath = Path.Combine(Application.StartupPath, @"..\..\Database\EduVault Database.accdb");

        OleDbConnection conn;

        private string StudentNo;

        public PaswordReset(string studentNo)
        {
            InitializeComponent();

            this.StudentNo = studentNo;

            conn = new OleDbConnection(
                $@"Provider=Microsoft.ACE.OLEDB.16.0;Data Source={dbPath};");
        }

        //Hash password (security improvement)
        private string HashPassword(string password)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }

        //Reset student password
        private void btnReset_Click(object sender, EventArgs e)
        {
            string newPassword = txtNewPassword.Text.Trim();
            string confirmPassword = txtConfirmPassword.Text.Trim();

            //Check match
            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.", "Validation Error");
                return;
            }

            //Check strength
            if (newPassword.Length < 8)
            {
                MessageBox.Show("Password must be at least 8 characters long.", "Validation Error");
                return;
            }

            try
            {
                conn.Open();

                string query = "UPDATE STUDENT SET StudentPassword = ? WHERE StudentNo = ?";

                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    //store hashed password
                    string hashedPassword = HashPassword(newPassword);

                    cmd.Parameters.AddWithValue("@StudentPassword", hashedPassword);
                    cmd.Parameters.AddWithValue("@StudentNo", StudentNo);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Password reset successfully!", "Success");

                        StudentSignIn studentSignIn = new StudentSignIn();
                        studentSignIn.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Failed to reset password.", "Error");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error resetting password: " + ex.Message, "Database Error");
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        private void PaswordReset_Load(object sender, EventArgs e)
        {

        }
    }
}