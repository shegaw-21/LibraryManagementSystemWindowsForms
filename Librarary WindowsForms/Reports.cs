// ReportsForm.cs
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using LibraryWindowsForms.Data; // Ensure this namespace is correct

namespace LibraryWindowsForms
{
    public partial class ReportsForm : Form
    {
        private DataTable dtOverdueBooks;

        public ReportsForm()
        {
            InitializeComponent();
            this.Text = "Book Library Management System - Reports";
            this.WindowState = FormWindowState.Maximized; // Maximize the form on load
            LoadOverdueBooksReport(); // Load initial report
        }

        private void LoadOverdueBooksReport()
        {
            // Query to get overdue books
            // DueDate < GETDATE() AND ReturnDate IS NULL
            string query = @"
                SELECT bb.BorrowedID, b.Title AS BookTitle, br.Name AS BorrowerName,
                       bb.BorrowDate, bb.DueDate
                FROM BorrowedBooks bb
                JOIN Books b ON bb.BookID = b.BookID
                JOIN Borrowers br ON bb.BorrowerID = br.BorrowerID
                WHERE bb.DueDate < GETDATE() AND bb.ReturnDate IS NULL
                ORDER BY bb.DueDate ASC"; // Order by due date to show most overdue first

            try
            {
                dtOverdueBooks = DbHelper.ExecuteQuery(query);
                dataGridViewReports.DataSource = dtOverdueBooks;

                // Display a message if no overdue books
                if (dtOverdueBooks.Rows.Count == 0)
                {
                    lblReportStatus.Text = "No overdue books found.";
                    lblReportStatus.Visible = true;
                }
                else
                {
                    lblReportStatus.Visible = false;
                }

                dataGridViewReports.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading the overdue books report: {ex.Message}", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblReportStatus.Text = "Error loading report.";
                lblReportStatus.Visible = true;
            }
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            LoadOverdueBooksReport(); // Regenerate report
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ManageForm manageForm = new ManageForm();
            manageForm.WindowState = FormWindowState.Maximized;
            manageForm.Show();
            this.Close();
        }

        private void ReportsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                bool manageFormIsOpen = false;
                foreach (Form f in Application.OpenForms)
                {
                    if (f is ManageForm && f.Visible)
                    {
                        manageFormIsOpen = true;
                        break;
                    }
                }

                if (!manageFormIsOpen)
                {
                    ManageForm manageForm = new ManageForm();
                    manageForm.WindowState = FormWindowState.Maximized;
                    manageForm.Show();
                }
            }
        }
    }
}
