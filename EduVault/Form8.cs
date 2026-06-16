using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;

namespace EduVault
{
    public partial class allApplicForm : Form
    {
        //Get database location
        string dbPath = Path.Combine(Application.StartupPath, @"..\..\Database\EduVault Database.accdb");

        OleDbConnection conn;

        public allApplicForm()
        {
            InitializeComponent();

            conn = new OleDbConnection(
                $@"Provider=Microsoft.ACE.OLEDB.16.0;Data Source={dbPath};");

            this.Load += new System.EventHandler(this.Form8_Load);
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            LoadApplications();
        }

        //Load all funding applications into the table
        private void LoadApplications()
        {
            string query = "SELECT * FROM FUNDINGAPPLICATION";

            try
            {
                conn.Open();
                OleDbDataAdapter da = new OleDbDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                ddgAllApplications.DataSource = dt;
                ddgAllApplications.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form5 dashboard = new Form5();
            dashboard.Show();
            this.Hide();
        }

        private void ddgAllApplications_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //Go back to the admin dashboard
        private void back_Click(object sender, EventArgs e)
        {
            Form5 adminDash = new Form5();
            adminDash.Show();
            this.Hide();
        }
    }
}