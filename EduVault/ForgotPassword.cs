using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EduVault
{
    public partial class ForgotPassword : Form
    {
        OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.16.0;Data Source=""C:\Users\2670142\OneDrive - University of Witwatersrand\EduVault (updated)\EduVault (2)-1\EduVault Database-1.accdb"";");
        public ForgotPassword()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            string studentNo = txtStudentNo.Text.Trim();
    

            if (string.IsNullOrWhiteSpace(studentNo))
            {
                MessageBox.Show("Please enter both Student Number and Email.", "Validation Error");
                return;
            }

            try
            {
                
                    conn.Open();
                    string query = "SELECT * FROM STUDENT WHERE StudentNo = ?";
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@StudentNo", studentNo);
                        

                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Identity verified — open reset form
                                PaswordReset paswordReset = new PaswordReset(studentNo);
                                paswordReset.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("No matching student found.", "Verification Failed");
                            }
                        }
                    }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error verifying identity: " + ex.Message, "Database Error");
            }

        }
    }
}
