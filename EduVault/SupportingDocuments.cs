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
    public partial class SupportingDocuments : Form
    {
        OleDbConnection conn = new OleDbConnection(
            @"Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\Users\leont\Downloads\ziplast\EduVault (updated)\EduVault (2)-1\EduVault Database-1.accdb;");

        //Upload tracking
        private bool idUploaded = false;
        private bool incomeUploaded = false;
        private bool residenceUploaded = false;
        private bool reportUploaded = false;
        private bool motivationUploaded = false;

        private string StudentNo;
        private int newApplicationID;

        public SupportingDocuments(string studentNo)
        {
            InitializeComponent();
            this.StudentNo = studentNo;
        }

        //Browse file safely
        private void BrowseFile(TextBox targetTextBox)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Select File";
                ofd.Filter = "All Files (*.*)|*.*";
                ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    FileInfo fi = new FileInfo(ofd.FileName);
                    double sizeMB = fi.Length / (1024.0 * 1024.0);

                    if (sizeMB > 5)
                    {
                        MessageBox.Show("File must not exceed 5 MB.", "Error");
                        return;
                    }

                    targetTextBox.Text = ofd.FileName;
                }
            }
        }

        private void btnBrowseID_Click(object sender, EventArgs e) => BrowseFile(txtIDPath);
        private void btnBrowseReport_Click(object sender, EventArgs e) => BrowseFile(txtReportPath);
        private void btnBrowseResidence_Click(object sender, EventArgs e) => BrowseFile(txtResidencePath);
        private void btnBrowseMotivation_Click(object sender, EventArgs e) => BrowseFile(txtMotivationPath);
        private void btnIncome_Click(object sender, EventArgs e) => BrowseFile(txtIncomePath);

        //Upload file safely
        private void UploadFile(TextBox sourceTextBox, string folderName, ref bool uploadFlag)
        {
            if (string.IsNullOrWhiteSpace(sourceTextBox.Text))
            {
                MessageBox.Show("Please select a file first.", "Error");
                return;
            }

            try
            {
                string destinationFolder = Path.Combine(Application.StartupPath, "Uploads", folderName);
                Directory.CreateDirectory(destinationFolder);

                string fileName = Path.GetFileName(sourceTextBox.Text);
                string destinationPath = Path.Combine(destinationFolder, fileName);

                File.Copy(sourceTextBox.Text, destinationPath, true);

                uploadFlag = true;

                MessageBox.Show($"{folderName} uploaded successfully!", "Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Upload failed: " + ex.Message, "Error");
            }
        }

        private void btnUploadID_Click(object sender, EventArgs e) => UploadFile(txtIDPath, "ID", ref idUploaded);
        private void btnUploadReport_Click(object sender, EventArgs e) => UploadFile(txtReportPath, "AcademicReport", ref reportUploaded);
        private void btnUploadResidence_Click(object sender, EventArgs e) => UploadFile(txtResidencePath, "ResidenceProof", ref residenceUploaded);
        private void btnUploadMotivation_Click(object sender, EventArgs e) => UploadFile(txtMotivationPath, "MotivationLetter", ref motivationUploaded);
        private void btnUploadIncome_Click(object sender, EventArgs e) => UploadFile(txtIncomePath, "IncomeProof", ref incomeUploaded);

        //Submit application
        private void button2_Click(object sender, EventArgs e)
        {
            //Basic safety check (light but useful)
            if (string.IsNullOrWhiteSpace(StudentNo))
            {
                MessageBox.Show("Student session invalid.", "Error");
                return;
            }

            string applicationStatus = "Pending";
            DateTime submissionDate = DateTime.Now;

            try
            {
                conn.Open();

                string insertQuery = @"INSERT INTO FUNDINGAPPLICATION
                (StudentNo, ApplicationStatus, ApplicationSubmissionDate)
                VALUES (?, ?, ?)";

                using (OleDbCommand cmd = new OleDbCommand(insertQuery, conn))
                {
                    cmd.Parameters.Add("?", OleDbType.VarChar).Value = StudentNo;
                    cmd.Parameters.Add("?", OleDbType.VarChar).Value = applicationStatus;
                    cmd.Parameters.Add("?", OleDbType.Date).Value = submissionDate;

                    cmd.ExecuteNonQuery();
                }

                using (OleDbCommand cmdGetID = new OleDbCommand("SELECT @@IDENTITY", conn))
                {
                    newApplicationID = Convert.ToInt32(cmdGetID.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error submitting application: " + ex.Message);
                return;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }

            //Confirmation step
            DialogResult result = MessageBox.Show(
                "Confirm that all information is correct before submission.",
                "Confirm Submission",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                Message MessageForm = new Message(newApplicationID, applicationStatus, submissionDate, StudentNo);
                MessageForm.Show();
                this.Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FundingAssistance FundingTypeForm = new FundingAssistance(StudentNo);
            FundingTypeForm.Show();
            this.Hide();
        }

        private void SupportingDocuments_Load(object sender, EventArgs e)
        {

        }
    }
}