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
    public partial class Form4 : Form
    {
        private string StudentNo;

        public Form4(string studentNo)
        {
            InitializeComponent();
            this.StudentNo = studentNo;
        }

        //Return to the sign in page
        private void button5_Click(object sender, EventArgs e)
        {
            StudentSignIn studentSignIn = new StudentSignIn();
            studentSignIn.Show();
            this.Hide();
        }

        //Open the student profile
        private void btnProfile_Click(object sender, EventArgs e)
        {
            StudentProfile profileForm = new StudentProfile(StudentNo);
            profileForm.Show();
            this.Hide();
        }

        //Close the application
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Open the funding application page
        private void btnApply_Click(object sender, EventArgs e)
        {
            FundingStudentProfile fundingStudentProfileForm = new FundingStudentProfile(StudentNo);
            fundingStudentProfileForm.Show();
            this.Hide();
        }

        private void btnStatus_Click(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}