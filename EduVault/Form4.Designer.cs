namespace EduVault
{
    partial class Form4
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
            this.btnApply = new System.Windows.Forms.Button();
            this.btnProfile = new System.Windows.Forms.Button();
            this.btnStatus = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // FORM
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 500);
            this.Text = "Student Dashboard";
            this.Name = "Form4";

            // BACKGROUND
            this.BackColor = System.Drawing.Color.WhiteSmoke;

            // LABEL (HEADER)
            this.label1.AutoSize = false;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Size = new System.Drawing.Size(800, 70);
            this.label1.Location = new System.Drawing.Point(50, 20);
            this.label1.Text = "Welcome to EduVault\nChoose an action to continue";

            // CARD STYLE BUTTON BASE (APPLY)
            this.btnApply.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnApply.Location = new System.Drawing.Point(80, 130);
            this.btnApply.Size = new System.Drawing.Size(220, 140);
            this.btnApply.Text = "Apply for Funding";
            this.btnApply.BackColor = System.Drawing.Color.White;
            this.btnApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            // STATUS CARD
            this.btnStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnStatus.Location = new System.Drawing.Point(340, 130);
            this.btnStatus.Size = new System.Drawing.Size(220, 140);
            this.btnStatus.Text = "View Application\nStatus";
            this.btnStatus.BackColor = System.Drawing.Color.White;
            this.btnStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            // PROFILE CARD
            this.btnProfile.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnProfile.Location = new System.Drawing.Point(600, 130);
            this.btnProfile.Size = new System.Drawing.Size(220, 140);
            this.btnProfile.Text = "View Profile";
            this.btnProfile.BackColor = System.Drawing.Color.White;
            this.btnProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            // LOGOUT (UTILITY BUTTON)
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnLogout.Location = new System.Drawing.Point(200, 320);
            this.btnLogout.Size = new System.Drawing.Size(200, 60);
            this.btnLogout.Text = "Log Out";
            this.btnLogout.BackColor = System.Drawing.Color.LightGray;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            // EXIT (UTILITY BUTTON)
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnExit.Location = new System.Drawing.Point(500, 320);
            this.btnExit.Size = new System.Drawing.Size(200, 60);
            this.btnExit.Text = "Exit";
            this.btnExit.BackColor = System.Drawing.Color.LightGray;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            // ADD CONTROLS
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnStatus);
            this.Controls.Add(this.btnProfile);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnExit);

            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.Button btnStatus;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnLogout;
    }
}