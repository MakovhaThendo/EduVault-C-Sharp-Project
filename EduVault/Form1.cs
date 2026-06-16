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
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        //Open student login
        private void btnStudent_Click(object sender, EventArgs e)
        {
            StudentSignIn f2 = new StudentSignIn();
            f2.Show();
            this.Hide();
        }

        //Open admin login
        private void btnAdmin_Click(object sender, EventArgs e)
        {
            AdminLogin f2 = new AdminLogin();
            f2.Show();
            this.Hide();
        }

        private void Welcome_Load(object sender, EventArgs e)
        {

        }
    }
}