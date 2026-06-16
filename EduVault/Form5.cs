using System;
using System.CodeDom.Compiler;
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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        //Open the reports page
        private void btnReport_Click(object sender, EventArgs e)
        {
            reportForm repForm = new reportForm();
            repForm.Show();
            this.Hide();
        }

        //View all funding applications
        private void btnViewAppl_Click(object sender, EventArgs e)
        {
            allApplicForm allApps = new allApplicForm();
            allApps.Show();
            this.Hide();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        //Return to the welcome screen
        private void btnLogout_Click(object sender, EventArgs e)
        {
            Welcome welcome = new Welcome();
            welcome.Show();
            this.Hide();
        }

        //Close the application
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}