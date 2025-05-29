// BookManagementForm.cs
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using LibraryWindowsForms.Data; // Ensure this namespace is correct and DbHelper is in this namespace

namespace LibraryWindowsForms
{
    public partial class BookManagementForm : Form
    {
        private DataTable dtBooks; // Store the DataTable for filtering

        public BookManagementForm()
        {
            InitializeComponent();
            this.Text = "Book Library Management System - Book Management";
            this.WindowState = FormWindowState.Maximized; // Maximize the form on load
            LoadBookData(); // Load data from DB
        }

        private void LoadBookData(string searchTerm = "")
        {
            string query = "SELECT BookID, Title, Author, ISBN, PublicationYear, TotalCopies, AvailableCopies FROM Books";
            List<SqlParameter> parameters = new List<SqlParameter>();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query += " WHERE Title LIKE @searchTerm OR Author LIKE @searchTerm OR ISBN LIKE @searchTerm";
                parameters.Add(new SqlParameter("@searchTerm", $"%{searchTerm}%"));
            }

            dtBooks = DbHelper.ExecuteQuery(query, parameters.ToArray());
            dataGridViewBooks.DataSource = dtBooks;

            // Optional: Auto-size columns to fit content
            dataGridViewBooks.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            List<string> fields = new List<string> { "Title", "Author", "ISBN", "PublicationYear", "TotalCopies", "AvailableCopies" };
            using (InputForm inputForm = new InputForm("Add New Book", fields))
            {
                if (inputForm.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Basic validation
                        if (string.IsNullOrWhiteSpace(inputForm.InputValues["Title"]) ||
                            string.IsNullOrWhiteSpace(inputForm.InputValues["Author"]) ||
                            string.IsNullOrWhiteSpace(inputForm.InputValues["ISBN"]))
                        {
                            MessageBox.Show("Title, Author, and ISBN cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        if (!int.TryParse(inputForm.InputValues["PublicationYear"], out int publicationYear) ||
                            !int.TryParse(inputForm.InputValues["TotalCopies"], out int totalCopies) ||
                            !int.TryParse(inputForm.InputValues["AvailableCopies"], out int availableCopies))
                        {
                            MessageBox.Show("Publication Year, Total Copies, and Available Copies must be valid numbers.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        string query = "INSERT INTO Books (Title, Author, ISBN, PublicationYear, TotalCopies, AvailableCopies) VALUES (@Title, @Author, @ISBN, @PublicationYear, @TotalCopies, @AvailableCopies)";
                        SqlParameter[] parameters = new SqlParameter[]
                        {
                            new SqlParameter("@Title", inputForm.InputValues["Title"]),
                            new SqlParameter("@Author", inputForm.InputValues["Author"]),
                            new SqlParameter("@ISBN", inputForm.InputValues["ISBN"]),
                            new SqlParameter("@PublicationYear", publicationYear),
                            new SqlParameter("@TotalCopies", totalCopies),
                            new SqlParameter("@AvailableCopies", availableCopies)
                        };

                        int rowsAffected = DbHelper.ExecuteNonQuery(query, parameters);
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Book added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadBookData(txtSearchBook.Text); // Refresh data after adding
                        }
                        else
                        {
                            MessageBox.Show("Failed to add book.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while adding book: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnEditBook_Click(object sender, EventArgs e)
        {
            if (dataGridViewBooks.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a book to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataGridViewRow selectedRow = dataGridViewBooks.SelectedRows[0];
            int bookId = Convert.ToInt32(selectedRow.Cells["BookID"].Value);

            // Populate current values for the edit form
            Dictionary<string, string> currentValues = new Dictionary<string, string>
            {
                { "Title", selectedRow.Cells["Title"].Value.ToString() },
                { "Author", selectedRow.Cells["Author"].Value.ToString() },
                { "ISBN", selectedRow.Cells["ISBN"].Value.ToString() },
                { "PublicationYear", selectedRow.Cells["PublicationYear"].Value.ToString() },
                { "TotalCopies", selectedRow.Cells["TotalCopies"].Value.ToString() },
                { "AvailableCopies", selectedRow.Cells["AvailableCopies"].Value.ToString() }
            };

            using (InputForm inputForm = new InputForm("Edit Book", currentValues))
            {
                if (inputForm.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Basic validation
                        if (string.IsNullOrWhiteSpace(inputForm.InputValues["Title"]) ||
                            string.IsNullOrWhiteSpace(inputForm.InputValues["Author"]) ||
                            string.IsNullOrWhiteSpace(inputForm.InputValues["ISBN"]))
                        {
                            MessageBox.Show("Title, Author, and ISBN cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        if (!int.TryParse(inputForm.InputValues["PublicationYear"], out int publicationYear) ||
                            !int.TryParse(inputForm.InputValues["TotalCopies"], out int totalCopies) ||
                            !int.TryParse(inputForm.InputValues["AvailableCopies"], out int availableCopies))
                        {
                            MessageBox.Show("Publication Year, Total Copies, and Available Copies must be valid numbers.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        string query = "UPDATE Books SET Title = @Title, Author = @Author, ISBN = @ISBN, PublicationYear = @PublicationYear, TotalCopies = @TotalCopies, AvailableCopies = @AvailableCopies WHERE BookID = @BookID";
                        SqlParameter[] parameters = new SqlParameter[]
                        {
                            new SqlParameter("@Title", inputForm.InputValues["Title"]),
                            new SqlParameter("@Author", inputForm.InputValues["Author"]),
                            new SqlParameter("@ISBN", inputForm.InputValues["ISBN"]),
                            new SqlParameter("@PublicationYear", publicationYear),
                            new SqlParameter("@TotalCopies", totalCopies),
                            new SqlParameter("@AvailableCopies", availableCopies),
                            new SqlParameter("@BookID", bookId)
                        };

                        int rowsAffected = DbHelper.ExecuteNonQuery(query, parameters);
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Book updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadBookData(txtSearchBook.Text); // Refresh data after updating
                        }
                        else
                        {
                            MessageBox.Show("Failed to update book.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while updating book: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnDeleteBook_Click(object sender, EventArgs e)
        {
            if (dataGridViewBooks.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a book to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult confirmResult = MessageBox.Show("Are you sure you want to delete this book?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    int bookId = Convert.ToInt32(dataGridViewBooks.SelectedRows[0].Cells["BookID"].Value);
                    string query = "DELETE FROM Books WHERE BookID = @BookID";
                    SqlParameter[] parameters = new SqlParameter[]
                    {
                        new SqlParameter("@BookID", bookId)
                    };

                    int rowsAffected = DbHelper.ExecuteNonQuery(query, parameters);
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Book deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadBookData(txtSearchBook.Text); // Refresh data after deleting
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete book.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while deleting book: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadBookData(txtSearchBook.Text); // Refresh data
        }

        private void txtSearchBook_TextChanged(object sender, EventArgs e)
        {
            // Filter the DataTable directly
            if (dtBooks != null)
            {
                string filter = txtSearchBook.Text;
                if (!string.IsNullOrWhiteSpace(filter))
                {
                    // Apply filter to all relevant columns
                    dtBooks.DefaultView.RowFilter = $"Title LIKE '%{filter}%' OR Author LIKE '%{filter}%' OR ISBN LIKE '%{filter}%'";
                }
                else
                {
                    dtBooks.DefaultView.RowFilter = ""; // Clear filter
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ManageForm manageForm = new ManageForm();
            manageForm.WindowState = FormWindowState.Maximized;
            manageForm.Show();
            this.Close();
        }

        private void BookManagementForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void dataGridViewBooks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Optional: Implement logic for cell content clicks if needed
        }
    }
}
