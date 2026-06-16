using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EduVault
{
    public partial class Message : Form
    {
        private int applicationID;
        private string applicationStatus;
        private DateTime submissionDate;
        private string StudentNo;

        public Message(int appID, string status, DateTime date, string studentNo)
        {
            InitializeComponent();

            //Store application details
            applicationID = appID;
            applicationStatus = status;
            submissionDate = date;
            this.StudentNo = studentNo;
        }

        private void Message_Load(object sender, EventArgs e)
        {
            //Display application details
            lblApplicationRef.Text = $": {applicationID}";
            lblStatus.Text = $": {applicationStatus}";
            lblSubDate.Text = $": {submissionDate.ToShortDateString()}";
        }

        //Return to dashboard
        private void button1_Click(object sender, EventArgs e)
        {
            Form4 dashboard = new Form4(StudentNo);
            dashboard.Show();
            this.Hide();
        }

        //Exit application
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}