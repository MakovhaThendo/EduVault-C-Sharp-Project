namespace EduVault
{
    partial class FundingAssistance
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
            this.label2 = new System.Windows.Forms.Label();
            this.cmbAssistanceType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.panelContent = new System.Windows.Forms.Panel();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();

            this.panelHeader.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();

            // =========================
            // HEADER PANEL
            // =========================
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Height = 80;
            this.panelHeader.BackColor = System.Drawing.Color.WhiteSmoke;

            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(160, 25);
            this.label1.Text = "Funding Assistance";

            this.panelHeader.Controls.Add(this.label1);

            // =========================
            // CONTENT PANEL
            // =========================
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Padding = new System.Windows.Forms.Padding(40);

            // Label 2
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label2.Location = new System.Drawing.Point(20, 30);
            this.label2.Text = "Select funding type:";

            // ComboBox
            this.cmbAssistanceType.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbAssistanceType.Location = new System.Drawing.Point(24, 60);
            this.cmbAssistanceType.Size = new System.Drawing.Size(300, 25);
            this.cmbAssistanceType.Items.AddRange(new object[]
            {
                "Full Tuition",
                "Partial Tuition",
                "Accommodation",
                "Books and Supplies"
            });

            // Label 3
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label3.Location = new System.Drawing.Point(20, 110);
            this.label3.Text = "Additional information (optional):";

            // TextBox
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.textBox1.Location = new System.Drawing.Point(24, 140);
            this.textBox1.Size = new System.Drawing.Size(500, 25);
            this.textBox1.Multiline = true;
            this.textBox1.Height = 100;

            this.panelContent.Controls.Add(this.label2);
            this.panelContent.Controls.Add(this.cmbAssistanceType);
            this.panelContent.Controls.Add(this.label3);
            this.panelContent.Controls.Add(this.textBox1);

            // =========================
            // BUTTON PANEL
            // =========================
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Height = 80;

            // Back Button
            this.button1.Text = "Back";
            this.button1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.button1.Size = new System.Drawing.Size(120, 40);
            this.button1.Location = new System.Drawing.Point(120, 20);
            this.button1.Click += new System.EventHandler(this.button1_Click);

            // Next Button
            this.button2.Text = "Next";
            this.button2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.button2.Size = new System.Drawing.Size(120, 40);
            this.button2.Location = new System.Drawing.Point(300, 20);
            this.button2.Click += new System.EventHandler(this.button2_Click);

            this.panelButtons.Controls.Add(this.button1);
            this.panelButtons.Controls.Add(this.button2);

            // =========================
            // FORM
            // =========================
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 400);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.panelHeader);

            this.Text = "Funding Assistance";

            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbAssistanceType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Panel panelButtons;

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}