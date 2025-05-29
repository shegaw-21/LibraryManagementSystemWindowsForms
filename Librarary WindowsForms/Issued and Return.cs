// IssueReturnForm.cs
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using LibraryWindowsForms.Data; // Ensure this namespace is correct

namespace LibraryWindowsForms
{
    public partial class IssueReturnForm : Form
    {
        private DataTable dtAvailableBooks;
        private DataTable dtBorrowers;
        private DataTable dtBorrowedBooks;

        public IssueReturnForm()
        {
            InitializeComponent();
            this.Text = "Book Library Management System - Issue/Return";
            this.WindowState = FormWindowState.Maximized; // Maximize the form on load
            LoadData(); // Load all necessary data
        }

        private void LoadData()
        {
            LoadAvailableBooks();
            LoadBorrowers();
            LoadBorrowedBooks();
        }

        private void LoadAvailableBooks(string searchTerm = "")
        {
            string query = "SELECT BookID, Title, Author, AvailableCopies FROM Books WHERE AvailableCopies > 0";
            List<SqlParameter> parameters = new List<SqlParameter>();
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query += " AND (Title LIKE @searchTerm OR Author LIKE @searchTerm)";
                parameters.Add(new SqlParameter("@searchTerm", $"%{searchTerm}%"));
            }
            dtAvailableBooks = DbHelper.ExecuteQuery(query, parameters.ToArray());
            dataGridViewAvailableBooks.DataSource = dtAvailableBooks;
            dataGridViewAvailableBooks.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void LoadBorrowers(string searchTerm = "")
        {
            string query = "SELECT BorrowerID, Name, Email FROM Borrowers";
            List<SqlParameter> parameters = new List<SqlParameter>();
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query += " WHERE (Name LIKE @searchTerm OR Email LIKE @searchTerm)";
                parameters.Add(new SqlParameter("@searchTerm", $"%{searchTerm}%"));
            }
            dtBorrowers = DbHelper.ExecuteQuery(query, parameters.ToArray());
            dataGridViewBorrowers.DataSource = dtBorrowers;
            dataGridViewBorrowers.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void LoadBorrowedBooks(string searchTerm = "")
        {
            string query = @"
                SELECT bb.BorrowedID, b.Title AS BookTitle, br.Name AS BorrowerName, bb.BorrowDate, bb.DueDate, bb.ReturnDate
                FROM BorrowedBooks bb
                JOIN Books b ON bb.BookID = b.BookID
                JOIN Borrowers br ON bb.BorrowerID = br.BorrowerID
                WHERE bb.ReturnDate IS NULL"; // Only show currently borrowed books

            List<SqlParameter> parameters = new List<SqlParameter>();
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query += " AND (b.Title LIKE @searchTerm OR br.Name LIKE @searchTerm)";
                parameters.Add(new SqlParameter("@searchTerm", $"%{searchTerm}%"));
            }
            dtBorrowedBooks = DbHelper.ExecuteQuery(query, parameters.ToArray());
            dataGridViewBorrowedBooks.DataSource = dtBorrowedBooks;
            dataGridViewBorrowedBooks.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void btnIssueBook_Click(object sender, EventArgs e)
        {
            if (dataGridViewAvailableBooks.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a book to issue.", "No Book Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (dataGridViewBorrowers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a borrower.", "No Borrower Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int bookId = Convert.ToInt32(dataGridViewAvailableBooks.SelectedRows[0].Cells["BookID"].Value);
            int borrowerId = Convert.ToInt32(dataGridViewBorrowers.SelectedRows[0].Cells["BorrowerID"].Value);
            DateTime borrowDate = DateTime.Today;
            DateTime dueDate = borrowDate.AddDays(14); // Example: Due in 14 days

            try
            {
                // 1. Insert into BorrowedBooks
                string insertQuery = "INSERT INTO BorrowedBooks (BookID, BorrowerID, BorrowDate, DueDate) VALUES (@BookID, @BorrowerID, @BorrowDate, @DueDate)";
                SqlParameter[] insertParams = new SqlParameter[]
                {
                    new SqlParameter("@BookID", bookId),
                    new SqlParameter("@BorrowerID", borrowerId),
                    new SqlParameter("@BorrowDate", borrowDate),
                    new SqlParameter("@DueDate", dueDate)
                };
                int insertRowsAffected = DbHelper.ExecuteNonQuery(insertQuery, insertParams);

                // 2. Update AvailableCopies in Books
                string updateBookQuery = "UPDATE Books SET AvailableCopies = AvailableCopies - 1 WHERE BookID = @BookID";
                SqlParameter[] updateBookParams = new SqlParameter[]
                {
                    new SqlParameter("@BookID", bookId)
                };
                int updateBookRowsAffected = DbHelper.ExecuteNonQuery(updateBookQuery, updateBookParams);

                if (insertRowsAffected > 0 && updateBookRowsAffected > 0)
                {
                    MessageBox.Show("Book issued successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData(); // Refresh all data grids
                }
                else
                {
                    MessageBox.Show("Failed to issue book. Database update failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while issuing book: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReturnBook_Click(object sender, EventArgs e)
        {
            if (dataGridViewBorrowedBooks.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a borrowed book to return.", "No Book Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult confirmResult = MessageBox.Show("Are you sure you want to return this book?", "Confirm Return", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    int borrowedId = Convert.ToInt32(dataGridViewBorrowedBooks.SelectedRows[0].Cells["BorrowedID"].Value);
                    DateTime returnDate = DateTime.Today;

                    // Get BookID associated with the borrowed record
                    string getBookIdQuery = "SELECT BookID FROM BorrowedBooks WHERE BorrowedID = @BorrowedID";
                    SqlParameter[] getBookIdParams = new SqlParameter[]
                    {
                        new SqlParameter("@BorrowedID", borrowedId)
                    };
                    object bookIdObj = DbHelper.ExecuteScalar(getBookIdQuery, getBookIdParams);
                    if (bookIdObj == null)
                    {
                        MessageBox.Show("Could not find associated book for return.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    int bookId = Convert.ToInt32(bookIdObj);

                    // 1. Update ReturnDate in BorrowedBooks
                    string updateBorrowedQuery = "UPDATE BorrowedBooks SET ReturnDate = @ReturnDate WHERE BorrowedID = @BorrowedID";
                    SqlParameter[] updateBorrowedParams = new SqlParameter[]
                    {
                        new SqlParameter("@ReturnDate", returnDate),
                        new SqlParameter("@BorrowedID", borrowedId)
                    };
                    int updateBorrowedRowsAffected = DbHelper.ExecuteNonQuery(updateBorrowedQuery, updateBorrowedParams);

                    // 2. Update AvailableCopies in Books
                    string updateBookQuery = "UPDATE Books SET AvailableCopies = AvailableCopies + 1 WHERE BookID = @BookID";
                    SqlParameter[] updateBookParams = new SqlParameter[]
                    {
                        new SqlParameter("@BookID", bookId)
                    };
                    int updateBookRowsAffected = DbHelper.ExecuteNonQuery(updateBookQuery, updateBookParams);

                    if (updateBorrowedRowsAffected > 0 && updateBookRowsAffected > 0)
                    {
                        MessageBox.Show("Book returned successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData(); // Refresh all data grids
                    }
                    else
                    {
                        MessageBox.Show("Failed to return book. Database update failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while returning book: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData(); // Refresh all data grids
        }

        private void txtSearchAvailableBooks_TextChanged(object sender, EventArgs e)
        {
            LoadAvailableBooks(txtSearchAvailableBooks.Text);
        }

        private void txtSearchBorrowers_TextChanged(object sender, EventArgs e)
        {
            LoadBorrowers(txtSearchBorrowers.Text);
        }

        private void txtSearchBorrowedBooks_TextChanged(object sender, EventArgs e)
        {
            LoadBorrowedBooks(txtSearchBorrowedBooks.Text);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ManageForm manageForm = new ManageForm();
            manageForm.WindowState = FormWindowState.Maximized;
            manageForm.Show();
            this.Close();
        }

        private void IssueReturnForm_FormClosing(object sender, FormClosingEventArgs e)
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
