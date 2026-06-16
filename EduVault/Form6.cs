using EduVault;
using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace EduVault
{
    public partial class Form6 : Form
    {
        //Get database location
        string dbPath = Path.Combine(Application.StartupPath, @"..\..\Database\EduVault Database.accdb");

        OleDbConnection conn;

        public Form6()
        {
            InitializeComponent();

            conn = new OleDbConnection(
                $@"Provider=Microsoft.ACE.OLEDB.16.0;Data Source={dbPath};");
        }

        // Hash password (SECURITY UPGRADE)
        private string HashPassword(string password)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }

        //Auto email generation
        private void txtStudentNo_TextChanged(object sender, EventArgs e)
        {
            string studentNo = txtStudentNo.Text.Trim();

            if (!string.IsNullOrEmpty(studentNo))
            {
                txtEmail.Text = studentNo + "@students.wits.ac.za";
            }
            else
            {
                txtEmail.Text = "";
            }
        }

        //Clear form
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtStudentNo.Text = "";
            txtFName.Text = "";
            txtLName.Text = "";
            dtpDOB.Value = DateTime.Today;
            txtContactNo.Text = "";
            txtEmail.Text = "";
            cmbFaculty.SelectedIndex = -1;
            cmbCourse.SelectedIndex = -1;
            txtPassword.Text = "";
            txtYOS.Text = "";
            txtStudentNo.Focus();
        }

        //Register student
        private void btnRegister_Click(object sender, EventArgs e)
        {
            string studentNo = txtStudentNo.Text.Trim();
            string firstName = txtFName.Text.Trim();
            string lastName = txtLName.Text.Trim();
            DateTime dob = dtpDOB.Value;
            string contact = txtContactNo.Text.Trim();
            string password = txtPassword.Text.Trim();
            string email = txtEmail.Text.Trim();
            string faculty = cmbFaculty.SelectedItem?.ToString();
            string course = cmbCourse.SelectedItem?.ToString();
            string yosStr = txtYOS.Text.Trim();

            bool blnValidInput = true;
            blnValidInput = ValidateInputs(blnValidInput, studentNo, firstName, lastName, dob, contact, password, email, faculty, course, yosStr);

            if (!blnValidInput)
                return;

            int yos = int.Parse(yosStr);

            // HASH PASSWORD HERE
            string hashedPassword = HashPassword(password);

            try
            {
                conn.Open();

                string query = @"INSERT INTO STUDENT 
                (StudentNo, StudentFName, StudentLName, StudentDOB, StudentContactInfo, StudentDegree, StudentCourse, StudentEmail, [StudentPassword], StudentYOS)
                VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";

                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StudentNo", studentNo);
                    cmd.Parameters.AddWithValue("@StudentFName", firstName);
                    cmd.Parameters.AddWithValue("@StudentLName", lastName);
                    cmd.Parameters.Add("@StudentDOB", OleDbType.Date).Value = dob;
                    cmd.Parameters.AddWithValue("@StudentContactInfo", contact);
                    cmd.Parameters.AddWithValue("@StudentDegree", faculty ?? "");
                    cmd.Parameters.AddWithValue("@StudentCourse", course ?? "");
                    cmd.Parameters.AddWithValue("@StudentEmail", email);

                    // STORE HASHED PASSWORD (IMPORTANT CHANGE)
                    cmd.Parameters.AddWithValue("@StudentPassword", hashedPassword);

                    cmd.Parameters.AddWithValue("@StudentYOS", yos);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Student registered successfully!", "Success");

                StudentSignIn studentSignIn = new StudentSignIn();
                studentSignIn.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving student: " + ex.Message, "Database Error");
            }
            finally
            {
                conn.Close();
            }
        }

        //Validation (unchanged)
        private bool ValidateInputs(bool blnValidInput, string studentNo, string firstName, string lastName, DateTime dob,
            string contact, string degree, string course, string email, string password, string yosStr)
        {
            if (string.IsNullOrWhiteSpace(studentNo))
            {
                MessageBox.Show("Please enter a valid Student Number.", "Validation Error");
                txtStudentNo.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(firstName))
            {
                MessageBox.Show("Please enter First Name.", "Validation Error");
                txtFName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(lastName))
            {
                MessageBox.Show("Please enter Last Name.", "Validation Error");
                txtLName.Focus();
                return false;
            }

            int age = DateTime.Now.Year - dob.Year;
            if (dob > DateTime.Now.AddYears(-age)) age--;
            if (age < 16)
            {
                MessageBox.Show("Student must be at least 16 years old.", "Validation Error");
                return false;
            }

            if (!txtContactNo.MaskCompleted)
            {
                MessageBox.Show("Please enter a valid contact number.", "Validation Error");
                txtContactNo.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(degree))
            {
                MessageBox.Show("Please select Degree.", "Validation Error");
                return false;
            }

            if (string.IsNullOrWhiteSpace(course))
            {
                MessageBox.Show("Please select Course.", "Validation Error");
                return false;
            }

            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Email must not be empty.", "Validation Error");
                return false;
            }

            if (string.IsNullOrWhiteSpace(password) || password.Length < 8)
            {
                MessageBox.Show("Password must be at least 8 characters long.", "Validation Error");
                txtPassword.Focus();
                return false;
            }

            if (!int.TryParse(yosStr, out int yos) || yos < 1 || yos > 6)
            {
                MessageBox.Show("Year of study must be a number between 1 and 6.", "Validation Error");
                txtYOS.Focus();
                return false;
            }

            return true;
        }

        //Back to login
        private void btnExit_Click(object sender, EventArgs e)
        {
            StudentSignIn loginForm = new StudentSignIn();
            loginForm.Show();
            this.Hide();
        }
    }
}