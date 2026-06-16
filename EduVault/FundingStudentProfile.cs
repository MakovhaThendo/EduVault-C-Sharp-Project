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
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace EduVault
{
    public partial class FundingStudentProfile : Form
    {
        //Get database location
        string dbPath = Path.Combine(Application.StartupPath, @"..\..\Database\EduVault Database.accdb");

        OleDbConnection conn;

        private string StudentNo;

        public FundingStudentProfile(string studentNo)
        {
            InitializeComponent();

            this.StudentNo = studentNo;

            conn = new OleDbConnection(
                $@"Provider=Microsoft.ACE.OLEDB.16.0;Data Source={dbPath};");
        }

        private bool isConfirmed = false;

        //Confirm student details
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            btnConfirm.ForeColor = Color.Gray;
            isConfirmed = true;
        }

        private void FundingStudentProfile_Load(object sender, EventArgs e)
        {
            LoadFundingStudentProfile();
        }

        //Load student details from database
        private void LoadFundingStudentProfile()
        {
            try
            {
                conn.Open();

                string query = "SELECT * FROM STUDENT WHERE StudentNo = @StudentNo";

                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StudentNo", StudentNo);

                    OleDbDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        txtFirstName.Text = reader["StudentFName"].ToString();
                        txtLastName.Text = reader["StudentLName"].ToString();
                        txtDOB.Text = Convert.ToDateTime(reader["StudentDOB"]).ToShortDateString();
                        txtEmailAdd.Text = reader["StudentContactInfo"].ToString();
                        txtDegree.Text = reader["StudentDegree"].ToString();
                        txtID.Text = reader["StudentNo"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Student not found!");
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving student profile: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        //Update financial means test and continue
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (!isConfirmed)
            {
                MessageBox.Show(
                    "Please click confirm before proceeding.",
                    "Confirmation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            string StudentFMTGrad = "";

            if (radLessThan350000.Checked)
            {
                StudentFMTGrad = "Less than 350000";
            }
            else if (radBetween.Checked)
            {
                StudentFMTGrad = "Between 350000 and 600000";
            }
            else if (radAbove.Checked)
            {
                StudentFMTGrad = "Above 600000";
            }
            else
            {
                MessageBox.Show("Please select the Financial means test", "Input Error");
                return;
            }

            try
            {
                conn.Open();

                string updateQuery = "UPDATE STUDENT SET StudentFMTGrad= @StudentFMTGrad WHERE StudentNo = @StudentNo";

                using (OleDbCommand cmd = new OleDbCommand(updateQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@StudentFMTGrad", StudentFMTGrad);
                    cmd.Parameters.AddWithValue("@StudentNo", StudentNo);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Financial Means Test updated successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Update failed. Student not found.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating financial means test: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

            FundingAssistance FundingAssistance = new FundingAssistance(StudentNo);
            FundingAssistance.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}