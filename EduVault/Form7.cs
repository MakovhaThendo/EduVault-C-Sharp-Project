using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;

namespace EduVault
{
    public partial class reportForm : Form
    {
        //Get database location
        string dbPath = Path.Combine(Application.StartupPath, @"..\..\Database\EduVault Database.accdb");

        OleDbConnection conn;

        public reportForm()
        {
            InitializeComponent();

            conn = new OleDbConnection(
                $@"Provider=Microsoft.ACE.OLEDB.16.0;Data Source={dbPath};");
        }

        //Load report options
        private void reportForm_Load(object sender, EventArgs e)
        {
            cmbReportType.Items.Clear();
            cmbReportType.Items.Add("Applications per Funding Status");
            cmbReportType.Items.Add("Applications per Funding Type");
            cmbReportType.Items.Add("Students with Multiple Applications");
            cmbReportType.SelectedIndex = 0;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form5 dashboard = new Form5();
            dashboard.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //Generate selected report
        private void btnGenerate_Click_1(object sender, EventArgs e)
        {
            if (cmbReportType.SelectedItem == null)
            {
                MessageBox.Show("Select a report type first.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string reportType = cmbReportType.SelectedItem.ToString();
            string query = "";

            //Choose the correct report query
            switch (reportType)
            {
                case "Applications per Funding Status":
                    query = @"SELECT IIF(ApplicationStatus IS NULL OR ApplicationStatus='', 'Pending', ApplicationStatus) AS [Status],
                                     COUNT(*) AS [Total Applications]
                              FROM FUNDINGAPPLICATION
                              GROUP BY IIF(ApplicationStatus IS NULL OR ApplicationStatus='', 'Pending', ApplicationStatus)";
                    break;

                case "Applications per Funding Type":
                    query = @"SELECT ApplicationFundingType AS [Funding Type],
                                     COUNT(*) AS [Total Applications]
                              FROM FUNDINGAPPLICATION
                              GROUP BY ApplicationFundingType";
                    break;

                case "Students with Multiple Applications":
                    query = @"SELECT StudentNo AS [Student Number],
                                     COUNT(*) AS [Applications Submitted]
                              FROM FUNDINGAPPLICATION
                              GROUP BY StudentNo
                              HAVING COUNT(*) > 1";
                    break;
            }

            try
            {
                conn.Open();

                OleDbDataAdapter da = new OleDbDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                //Display report in the table
                dataGridView1.DataSource = dt;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                MessageBox.Show("Report generated and saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error");
            }
            finally
            {
                conn.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        //Return to the applications page
        private void button1_Click_1(object sender, EventArgs e)
        {
            allApplicForm loginForm = new allApplicForm();
            loginForm.Show();
            this.Hide();
        }
    }
}