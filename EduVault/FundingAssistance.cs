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
    public partial class FundingAssistance : Form
    {
        //Get database location
        string dbPath = Path.Combine(Application.StartupPath, @"..\..\Database\EduVault Database.accdb");

        OleDbConnection conn;

        private string StudentNo;

        public FundingAssistance(string studentNo)
        {
            InitializeComponent();

            this.StudentNo = studentNo;

            conn = new OleDbConnection(
                $@"Provider=Microsoft.ACE.OLEDB.16.0;Data Source={dbPath};");
        }

        //Save selected funding type and continue
        private void button2_Click(object sender, EventArgs e)
        {
            if (cmbAssistanceType.SelectedIndex == -1)
            {
                MessageBox.Show("Please select the type of funding before proceeding.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedFundingType = cmbAssistanceType.SelectedItem.ToString();

            try
            {
                conn.Open();

                string insertQuery = @"INSERT INTO FUNDINGAPPLICATION
            (StudentNo, ApplicationFundingType)
            VALUES (@StudentNo, @FundingType)";

                using (OleDbCommand cmd = new OleDbCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@StudentNo", StudentNo);
                    cmd.Parameters.AddWithValue("@FundingType", selectedFundingType);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Funding type saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving funding application: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

            SupportingDocuments SupportingDocuments = new SupportingDocuments(StudentNo);
            SupportingDocuments.Show();
            this.Hide();
        }

        //Go back to student profile
        private void button1_Click(object sender, EventArgs e)
        {
            FundingStudentProfile studentProfile = new FundingStudentProfile(StudentNo);
            studentProfile.Show();
            this.Hide();
        }

        private void FundingAssistance_Load(object sender, EventArgs e)
        {

        }
    }
}