// Manage.cs
using System;
using System.Windows.Forms;

namespace LibraryWindowsForms
{
    public partial class ManageForm : Form
    {
        public ManageForm()
        {
            InitializeComponent();
            this.Text = "Book Library Management System - Main Management";
            this.WindowState = FormWindowState.Maximized; // Maximize the form on load
        }

        private void btnBookManagement_Click(object sender, EventArgs e)
        {
            // Open the BookManagementForm
            BookManagementForm bookForm = new BookManagementForm();
            bookForm.WindowState = FormWindowState.Maximized;
            bookForm.Show();
            this.Hide(); // Hide the current form
        }

        private void btnBorrowerManagement_Click(object sender, EventArgs e)
        {
            // Open the BorrowerManagementForm
            BorrowerManagementForm borrowerForm = new BorrowerManagementForm();
            borrowerForm.WindowState = FormWindowState.Maximized;
            borrowerForm.Show();
            this.Hide(); // Hide the current form
        }

        private void btnIssueReturn_Click(object sender, EventArgs e)
        {
            // Open the IssueReturnForm
            IssueReturnForm issueReturnForm = new IssueReturnForm();
            issueReturnForm.WindowState = FormWindowState.Maximized;
            issueReturnForm.Show();
            this.Hide(); // Hide the current form
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            // Open the ReportsForm
            ReportsForm reportsForm = new ReportsForm(); // Instantiate the new form
            reportsForm.WindowState = FormWindowState.Maximized;
            reportsForm.Show();
            this.Hide(); // Hide the current form
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Show the LoginForm and close the current form
            LoginForm loginForm = new LoginForm();
            loginForm.WindowState = FormWindowState.Maximized;
            loginForm.Show();
            this.Close();
        }

        private void ManageForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Ensure the application exits if the main management form is closed directly
            // and no other forms are open (e.g., login form)
            if (e.CloseReason == CloseReason.UserClosing)
            {
                bool loginFormIsOpen = false;
                foreach (Form f in Application.OpenForms)
                {
                    if (f is LoginForm && f.Visible)
                    {
                        loginFormIsOpen = true;
                        break;
                    }
                }

                if (!loginFormIsOpen)
                {
                    Application.Exit();
                }
            }
        }
    }
}
