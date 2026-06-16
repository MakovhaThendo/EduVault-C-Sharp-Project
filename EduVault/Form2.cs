using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EduVault
{
    public partial class StudentSignIn : Form
    {
        //Get database location
        string dbPath = Path.Combine(Application.StartupPath, @"..\..\Database\EduVault Database.accdb");

        OleDbConnection conn;

        public StudentSignIn()
        {
            InitializeComponent();

            conn = new OleDbConnection(
                $@"Provider=Microsoft.ACE.OLEDB.16.0;Data Source={dbPath};");
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        //Open the registration page
        private void btnGoRegister_Click(object sender, EventArgs e)
        {
            Form6 f2 = new Form6();
            f2.Show();
            this.Hide();
        }

        //Check student login details
        private void button1_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            bool blnValidInput = true;

            blnValidInput = ValidateLogin(blnValidInput, email, password);

            if (blnValidInput)
            {
                try
                {
                    conn.Open();

                    string query = "SELECT StudentNo FROM STUDENT WHERE StudentEmail = @StudentEmail AND [StudentPassword]=@StudentPassword";

                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@StudentEmail", email);
                        cmd.Parameters.AddWithValue("@StudentPassword", password);

                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            string StudentNo = result.ToString();

                            txtPassword.Clear();

                            MessageBox.Show("Login Successful!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            Form4 dashboard = new Form4(StudentNo);
                            dashboard.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Invalid email or password, try again", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            txtPassword.Clear();
                            txtPassword.Focus();
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR" + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        //Validate login input
        private bool ValidateLogin(bool blnValidInput, string email, string password)
        {
            //Validate Email address
            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Please enter your email", "ERROR");
                blnValidInput = false;
            }

            //Validate password
            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter your password", "ERROR");
                blnValidInput = false;
            }

            return blnValidInput;
        }

        //Clear inputs
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtPassword.Text = "";
            txtEmail.Text = "";
        }

        //Return to the welcome page
        private void btnBack_Click(object sender, EventArgs e)
        {
            Welcome welcome = new Welcome();
            welcome.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgotPassword forgotPassword = new ForgotPassword();
            forgotPassword.Show();
            this.Hide();
        }

        private void StudentSignIn_Load(object sender, EventArgs e)
        {

        }
    }
}