// LoginForm.cs
using System;
using System.Windows.Forms;

namespace LibraryWindowsForms 
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            this.Text = "Book Library Management System - Login";
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (username == "admin" && password == "1234")
            {
                // Successful login
                MessageBox.Show("Login Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Create an instance of the ManageForm
                ManageForm manageForm = new ManageForm();
                manageForm.WindowState = FormWindowState.Maximized; // Ensure next form is also maximized
                manageForm.Show();

                
                this.Hide();
            }
            else
            {
                // Failed login
                MessageBox.Show("Invalid Username or Password. Please try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear(); // Clear password field for security
                txtUsername.Focus(); // Set focus back to username
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
          
            Application.Exit();
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnLogin_Click(sender, e); // Simulate login button click
                e.Handled = true; // Prevent the 'ding' sound
            }
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPassword.Checked)
            {
                txtPassword.PasswordChar = '\0'; // Show password (null character)
            }
            else
            {
                txtPassword.PasswordChar = '*'; // Hide password with asterisk
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
