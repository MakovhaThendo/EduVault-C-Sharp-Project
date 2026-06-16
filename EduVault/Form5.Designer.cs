namespace EduVault
{
    partial class Form5
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnUpdateAppl = new System.Windows.Forms.Button();
            this.btnViewAppl = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // FORM
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 520);
            this.Name = "Form5";
            this.Text = "Administrator Dashboard";
            this.BackColor = System.Drawing.Color.WhiteSmoke;

            // HEADER LABEL
            this.label1.AutoSize = false;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Size = new System.Drawing.Size(850, 80);
            this.label1.Location = new System.Drawing.Point(25, 20);
            this.label1.Text = "Administrator Control Panel\nSelect an action to manage applications";

            // VIEW APPLICANTS CARD
            this.btnViewAppl.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnViewAppl.Location = new System.Drawing.Point(80, 140);
            this.btnViewAppl.Size = new System.Drawing.Size(220, 140);
            this.btnViewAppl.Text = "View All Applicants";
            this.btnViewAppl.BackColor = System.Drawing.Color.White;
            this.btnViewAppl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            // UPDATE APPLICANT CARD
            this.btnUpdateAppl.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnUpdateAppl.Location = new System.Drawing.Point(340, 140);
            this.btnUpdateAppl.Size = new System.Drawing.Size(220, 140);
            this.btnUpdateAppl.Text = "Update Applicant Info";
            this.btnUpdateAppl.BackColor = System.Drawing.Color.White;
            this.btnUpdateAppl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            // REPORT CARD
            this.btnReport.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnReport.Location = new System.Drawing.Point(600, 140);
            this.btnReport.Size = new System.Drawing.Size(220, 140);
            this.btnReport.Text = "Generate Reports";
            this.btnReport.BackColor = System.Drawing.Color.White;
            this.btnReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            // LOGOUT (UTILITY)
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnLogout.Location = new System.Drawing.Point(220, 330);
            this.btnLogout.Size = new System.Drawing.Size(200, 60);
            this.btnLogout.Text = "Log Out";
            this.btnLogout.BackColor = System.Drawing.Color.LightGray;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            // EXIT (UTILITY)
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnExit.Location = new System.Drawing.Point(480, 330);
            this.btnExit.Size = new System.Drawing.Size(200, 60);
            this.btnExit.Text = "Exit";
            this.btnExit.BackColor = System.Drawing.Color.LightGray;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            // ADD CONTROLS
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnViewAppl);
            this.Controls.Add(this.btnUpdateAppl);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnExit);

            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnUpdateAppl;
        private System.Windows.Forms.Button btnViewAppl;
        private System.Windows.Forms.Button btnReport;
    }
}