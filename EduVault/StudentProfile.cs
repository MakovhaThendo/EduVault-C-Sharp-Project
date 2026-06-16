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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace EduVault
{
    public partial class StudentProfile : Form
    {
        //Get database location (safer than hardcoding full path)
        string dbPath = Path.Combine(Application.StartupPath, @"..\..\Database\EduVault Database.accdb");

        OleDbConnection conn;

        // Logged-in student number
        private string StudentNo;

        public StudentProfile(string studentNo)
        {
            InitializeComponent();

            this.StudentNo = studentNo;

            conn = new OleDbConnection(
                $@"Provider=Microsoft.ACE.OLEDB.16.0;Data Source={dbPath};");

            LoadStudentProfile();
        }

        // Load student profile from database
        private void LoadStudentProfile()
        {
            try
            {
                conn.Open();

                string query = "SELECT * FROM STUDENT WHERE StudentNo = ?";

                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StudentNo", StudentNo);

                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtStudentNo.Text = reader["StudentNo"].ToString();
                            txtFName.Text = reader["StudentFName"].ToString();
                            txtLName.Text = reader["StudentLName"].ToString();
                            dtpDOB.Value = Convert.ToDateTime(reader["StudentDOB"]);
                            txtContactNo.Text = reader["StudentContactInfo"].ToString();
                            txtEmail.Text = reader["StudentEmail"].ToString();
                            txtPassword.Text = reader["StudentPassword"].ToString();

                            // Lock fields (only contact editable)
                            txtStudentNo.ReadOnly = true;
                            txtFName.ReadOnly = true;
                            txtLName.ReadOnly = true;
                            dtpDOB.Enabled = false;
                            txtEmail.ReadOnly = true;
                            txtPassword.ReadOnly = true;

                            txtContactNo.ReadOnly = false;
                        }
                        else
                        {
                            MessageBox.Show("Student profile not found.", "Error");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading profile: " + ex.Message, "Database Error");
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        // Update student contact number
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string contact = txtContactNo.Text.Trim();

            //Validation
            if (!ValidateInputs(contact))
                return;

            try
            {
                conn.Open();

                string query = @"UPDATE STUDENT 
                                 SET StudentContactInfo = ?
                                 WHERE StudentNo = ?";

                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StudentContactInfo", contact);
                    cmd.Parameters.AddWithValue("@StudentNo", StudentNo);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Contact number updated successfully!", "Success");
                    }
                    else
                    {
                        MessageBox.Show("No matching student found to update.", "Update Failed");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating profile: " + ex.Message, "Database Error");
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        // Validate contact input
        private bool ValidateInputs(string contact)
        {
            if (string.IsNullOrWhiteSpace(contact))
            {
                MessageBox.Show("Please enter contact number.", "Validation Error");
                txtContactNo.Focus();
                return false;
            }

            if (!txtContactNo.MaskCompleted)
            {
                MessageBox.Show("Please enter a valid contact number.", "Validation Error");
                txtContactNo.Focus();
                return false;
            }

            return true;
        }

        // Back to dashboard
        private void btnBack_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4(StudentNo);
            form4.Show();
            this.Hide();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void StudentProfile_Load(object sender, EventArgs e)
        {

        }
    }
}