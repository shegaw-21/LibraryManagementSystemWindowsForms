// Manage.Designer.cs
namespace LibraryWindowsForms
{
    partial class ManageForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnBookManagement = new System.Windows.Forms.Button();
            this.btnBorrowerManagement = new System.Windows.Forms.Button();
            this.btnIssueReturn = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.SuspendLayout();
            //
            // btnBookManagement
            //
            this.btnBookManagement.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnBookManagement.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBookManagement.Location = new System.Drawing.Point(300, 150);
            this.btnBookManagement.Name = "btnBookManagement";
            this.btnBookManagement.Size = new System.Drawing.Size(200, 60);
            this.btnBookManagement.TabIndex = 0;
            this.btnBookManagement.Text = "Book Management";
            this.btnBookManagement.UseVisualStyleBackColor = true;
            this.btnBookManagement.Click += new System.EventHandler(this.btnBookManagement_Click);
            //
            // btnBorrowerManagement
            //
            this.btnBorrowerManagement.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnBorrowerManagement.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBorrowerManagement.Location = new System.Drawing.Point(300, 230);
            this.btnBorrowerManagement.Name = "btnBorrowerManagement";
            this.btnBorrowerManagement.Size = new System.Drawing.Size(200, 60);
            this.btnBorrowerManagement.TabIndex = 1;
            this.btnBorrowerManagement.Text = "Borrower Management";
            this.btnBorrowerManagement.UseVisualStyleBackColor = true;
            this.btnBorrowerManagement.Click += new System.EventHandler(this.btnBorrowerManagement_Click);
            //
            // btnIssueReturn
            //
            this.btnIssueReturn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnIssueReturn.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIssueReturn.Location = new System.Drawing.Point(300, 310);
            this.btnIssueReturn.Name = "btnIssueReturn";
            this.btnIssueReturn.Size = new System.Drawing.Size(200, 60);
            this.btnIssueReturn.TabIndex = 2;
            this.btnIssueReturn.Text = "Issue/Return Books";
            this.btnIssueReturn.UseVisualStyleBackColor = true;
            this.btnIssueReturn.Click += new System.EventHandler(this.btnIssueReturn_Click);
            //
            // btnReports
            //
            this.btnReports.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnReports.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReports.Location = new System.Drawing.Point(300, 390);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(200, 60);
            this.btnReports.TabIndex = 3;
            this.btnReports.Text = "Reports";
            this.btnReports.UseVisualStyleBackColor = true;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            //
            // btnLogout
            //
            this.btnLogout.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.Location = new System.Drawing.Point(350, 500);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(100, 40);
            this.btnLogout.TabIndex = 4;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            //
            // lblWelcome
            //
            this.lblWelcome.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.Location = new System.Drawing.Point(200, 70);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(400, 37);
            this.lblWelcome.TabIndex = 5;
            this.lblWelcome.Text = "Welcome to MyLibrary System!";
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // ManageForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600); // Default size, will be maximized
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnReports);
            this.Controls.Add(this.btnIssueReturn);
            this.Controls.Add(this.btnBorrowerManagement);
            this.Controls.Add(this.btnBookManagement);
            this.Name = "ManageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ManageForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ManageForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBookManagement;
        private System.Windows.Forms.Button btnBorrowerManagement;
        private System.Windows.Forms.Button btnIssueReturn;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblWelcome;
    }
}
