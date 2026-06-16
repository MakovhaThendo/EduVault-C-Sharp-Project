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
    public partial class AdminLogin : Form
    {
        //Get database location
        string dbPath = Path.Combine(Application.StartupPath, @"..\..\Database\EduVault Database.accdb");

        OleDbConnection conn;

        public AdminLogin()
        {
            InitializeComponent();

            conn = new OleDbConnection(
                $@"Provider=Microsoft.ACE.OLEDB.16.0;Data Source={dbPath};");
        }

        //Hash password (SECURITY UPGRADE)
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string FirstName = txtFName.Text.Trim();
            string LastName = txtLName.Text.Trim();
            string Password = txtPassword.Text.Trim();
            bool blnValidInput = true;

            blnValidInput = ValidateLogin(blnValidInput, FirstName, LastName, Password);

            if (blnValidInput)
            {
                try
                {
                    conn.Open();

                    string query = "SELECT COUNT(*) FROM ADMINISTRATOR WHERE AdminFName = @AdminFName AND AdminLName = @AdminLName AND [Adminpassword] = @AdminPassword";

                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@AdminFName", FirstName);
                        cmd.Parameters.AddWithValue("@AdminLName", LastName);

                        //SECURE: compare hashed password
                        cmd.Parameters.AddWithValue("@AdminPassword", HashPassword(Password));

                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        if (count > 0)
                        {
                            txtPassword.Clear();

                            MessageBox.Show("Login Successful!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            Form5 AdminWork = new Form5();
                            AdminWork.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Invalid username or password. Try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            txtPassword.Clear();
                            txtPassword.Focus();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Welcome welcome = new Welcome();
            welcome.Show();
            this.Hide();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtFName.Text = "";
            txtLName.Text = "";
            txtPassword.Text = "";
            txtFName.Focus();
        }

        private bool ValidateLogin(bool blnValidInput, string FirstName,
            string LastName, string Password)
        {
            if (string.IsNullOrEmpty(FirstName))
            {
                MessageBox.Show("Please enter your First Name", "Error");
                blnValidInput = false;
            }

            if (string.IsNullOrEmpty(LastName))
            {
                MessageBox.Show("Please enter your Last Name", "Error");
                blnValidInput = false;
            }

            if (string.IsNullOrEmpty(Password))
            {
                MessageBox.Show("Please enter your Password", "Error");
                blnValidInput = false;
            }

            return blnValidInput;
        }

        private void label3_Click(object sender, EventArgs e) { }

        private void label1_Click(object sender, EventArgs e) { }

        private void AdminLogin_Load(object sender, EventArgs e) { }
    }
}