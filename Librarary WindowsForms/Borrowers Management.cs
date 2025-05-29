// BorrowerManagementForm.cs
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using LibraryWindowsForms.Data; // Ensure this namespace is correct and DbHelper is in this namespace

namespace LibraryWindowsForms
{
    public partial class BorrowerManagementForm : Form
    {
        private DataTable dtBorrowers; // Store the DataTable for filtering

        public BorrowerManagementForm()
        {
            InitializeComponent();
            this.Text = "Book Library Management System - Borrower Management";
            this.WindowState = FormWindowState.Maximized; // Maximize the form on load
            LoadBorrowerData(); // Load data from DB
        }

        private void LoadBorrowerData(string searchTerm = "")
        {
            string query = "SELECT BorrowerID, Name, Email, Phone FROM Borrowers";
            List<SqlParameter> parameters = new List<SqlParameter>();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query += " WHERE Name LIKE @searchTerm OR Email LIKE @searchTerm OR Phone LIKE @searchTerm";
                parameters.Add(new SqlParameter("@searchTerm", $"%{searchTerm}%"));
            }

            dtBorrowers = DbHelper.ExecuteQuery(query, parameters.ToArray());
            dataGridViewBorrowers.DataSource = dtBorrowers;

            // Optional: Auto-size columns to fit content
            dataGridViewBorrowers.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void btnAddBorrower_Click(object sender, EventArgs e)
        {
            List<string> fields = new List<string> { "Name", "Email", "Phone" };
            using (InputForm inputForm = new InputForm("Add New Borrower", fields))
            {
                if (inputForm.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Basic validation
                        if (string.IsNullOrWhiteSpace(inputForm.InputValues["Name"]) ||
                            string.IsNullOrWhiteSpace(inputForm.InputValues["Email"]))
                        {
                            MessageBox.Show("Name and Email cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // Basic email format validation (more robust regex can be used)
                        if (!inputForm.InputValues["Email"].Contains("@") || !inputForm.InputValues["Email"].Contains("."))
                        {
                            MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        string query = "INSERT INTO Borrowers (Name, Email, Phone) VALUES (@Name, @Email, @Phone)";
                        SqlParameter[] parameters = new SqlParameter[]
                        {
                            new SqlParameter("@Name", inputForm.InputValues["Name"]),
                            new SqlParameter("@Email", inputForm.InputValues["Email"]),
                            new SqlParameter("@Phone", inputForm.InputValues["Phone"])
                        };

                        int rowsAffected = DbHelper.ExecuteNonQuery(query, parameters);
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Borrower added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadBorrowerData(txtSearchBorrower.Text); // Refresh data after adding
                        }
                        else
                        {
                            MessageBox.Show("Failed to add borrower.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while adding borrower: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnEditBorrower_Click(object sender, EventArgs e)
        {
            if (dataGridViewBorrowers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a borrower to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataGridViewRow selectedRow = dataGridViewBorrowers.SelectedRows[0];
            int borrowerId = Convert.ToInt32(selectedRow.Cells["BorrowerID"].Value);

            // Populate current values for the edit form
            Dictionary<string, string> currentValues = new Dictionary<string, string>
            {
                { "Name", selectedRow.Cells["Name"].Value.ToString() },
                { "Email", selectedRow.Cells["Email"].Value.ToString() },
                { "Phone", selectedRow.Cells["Phone"].Value.ToString() }
            };

            using (InputForm inputForm = new InputForm("Edit Borrower", currentValues))
            {
                if (inputForm.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Basic validation
                        if (string.IsNullOrWhiteSpace(inputForm.InputValues["Name"]) ||
                            string.IsNullOrWhiteSpace(inputForm.InputValues["Email"]))
                        {
                            MessageBox.Show("Name and Email cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // Basic email format validation
                        if (!inputForm.InputValues["Email"].Contains("@") || !inputForm.InputValues["Email"].Contains("."))
                        {
                            MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        string query = "UPDATE Borrowers SET Name = @Name, Email = @Email, Phone = @Phone WHERE BorrowerID = @BorrowerID";
                        SqlParameter[] parameters = new SqlParameter[]
                        {
                            new SqlParameter("@Name", inputForm.InputValues["Name"]),
                            new SqlParameter("@Email", inputForm.InputValues["Email"]),
                            new SqlParameter("@Phone", inputForm.InputValues["Phone"]),
                            new SqlParameter("@BorrowerID", borrowerId)
                        };

                        int rowsAffected = DbHelper.ExecuteNonQuery(query, parameters);
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Borrower updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadBorrowerData(txtSearchBorrower.Text); // Refresh data after updating
                        }
                        else
                        {
                            MessageBox.Show("Failed to update borrower.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while updating borrower: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnDeleteBorrower_Click(object sender, EventArgs e)
        {
            if (dataGridViewBorrowers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a borrower to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult confirmResult = MessageBox.Show("Are you sure you want to delete this borrower?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    int borrowerId = Convert.ToInt32(dataGridViewBorrowers.SelectedRows[0].Cells["BorrowerID"].Value);
                    string query = "DELETE FROM Borrowers WHERE BorrowerID = @BorrowerID";
                    SqlParameter[] parameters = new SqlParameter[]
                    {
                        new SqlParameter("@BorrowerID", borrowerId)
                    };

                    int rowsAffected = DbHelper.ExecuteNonQuery(query, parameters);
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Borrower deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadBorrowerData(txtSearchBorrower.Text); // Refresh data after deleting
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete borrower.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while deleting borrower: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadBorrowerData(txtSearchBorrower.Text); // Refresh data
        }

        private void txtSearchBorrower_TextChanged(object sender, EventArgs e)
        {
            // Filter the DataTable directly
            if (dtBorrowers != null)
            {
                string filter = txtSearchBorrower.Text;
                if (!string.IsNullOrWhiteSpace(filter))
                {
                    // Apply filter to all relevant columns
                    dtBorrowers.DefaultView.RowFilter = $"Name LIKE '%{filter}%' OR Email LIKE '%{filter}%' OR Phone LIKE '%{filter}%'";
                }
                else
                {
                    dtBorrowers.DefaultView.RowFilter = ""; // Clear filter
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

        private void BorrowerManagementForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void dataGridViewBorrowers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Optional: Implement logic for cell content clicks if needed
        }

        private void BorrowerManagementForm_Load(object sender, EventArgs e)
        {

        }
    }
}
