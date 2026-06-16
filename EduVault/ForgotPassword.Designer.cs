namespace EduVault
{
    partial class ForgotPassword
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
            this.label3 = new System.Windows.Forms.Label();
            this.btnVerify = new System.Windows.Forms.Button();
            this.txtStudentNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();

            // 
            // panel1 (header container)
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Height = 70;
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.Controls.Add(this.label3);

            // 
            // label3 (title)
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(300, 20);
            this.label3.Name = "label3";
            this.label3.Text = "Profile Verification";

            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(180, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 17);
            this.label4.Text = "Student Number:";

            // 
            // txtStudentNo
            // 
            this.txtStudentNo.Location = new System.Drawing.Point(310, 137);
            this.txtStudentNo.Size = new System.Drawing.Size(220, 22);
            this.txtStudentNo.Name = "txtStudentNo";

            // 
            // btnVerify
            // 
            this.btnVerify.Location = new System.Drawing.Point(310, 190);
            this.btnVerify.Size = new System.Drawing.Size(220, 35);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Text = "Verify";
            this.btnVerify.UseVisualStyleBackColor = true;
            this.btnVerify.BackColor = System.Drawing.Color.SteelBlue;
            this.btnVerify.ForeColor = System.Drawing.Color.White;
            this.btnVerify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerify.Click += new System.EventHandler(this.button1_Click);

            // 
            // ForgotPassword Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnVerify);
            this.Controls.Add(this.txtStudentNo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel1);

            this.Name = "ForgotPassword";
            this.Text = "Forgot Password";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnVerify;
        private System.Windows.Forms.TextBox txtStudentNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
    }
}