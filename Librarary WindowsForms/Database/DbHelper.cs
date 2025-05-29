// DbHelper.cs
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms; // Required for MessageBox

namespace LibraryWindowsForms.Data // IMPORTANT: Ensure this matches your project structure
{
    public static class DbHelper
    {
        // IMPORTANT: Replace with your actual SQL Server instance name
        private static readonly string connectionString =
            "Data Source=DESKTOP-S59KTFH;Initial Catalog=MyLibraryDB;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;";

        /// <summary>
        /// Executes a SQL query that returns a DataTable (e.g., SELECT statements).
        /// </summary>
        /// <param name="query">The SQL query string.</param>
        /// <param name="parameters">Optional array of SqlParameter objects.</param>
        /// <returns>A DataTable containing the query results.</returns>
        public static DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        if (parameters != null)
                        {
                            command.Parameters.AddRange(parameters);
                        }
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Display user-friendly error message
                MessageBox.Show($"Database Error (Query): {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Log the full exception for debugging
                Console.WriteLine($"Database Error (Query): {ex.Message}\n{ex.StackTrace}");
            }
            return dataTable;
        }

        /// <summary>
        /// Executes a SQL command that does not return data (e.g., INSERT, UPDATE, DELETE).
        /// </summary>
        /// <param name="query">The SQL command string.</param>
        /// <param name="parameters">Optional array of SqlParameter objects.</param>
        /// <returns>The number of rows affected.</returns>
        public static int ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            int rowsAffected = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        if (parameters != null)
                        {
                            command.Parameters.AddRange(parameters);
                        }
                        rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Display user-friendly error message
                MessageBox.Show($"Database Error (Non-Query): {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Log the full exception for debugging
                Console.WriteLine($"Database Error (Non-Query): {ex.Message}\n{ex.StackTrace}");
            }
            return rowsAffected;
        }

        /// <summary>
        /// Executes a SQL query that returns a single scalar value (e.g., COUNT, MAX).
        /// </summary>
        /// <param name="query">The SQL query string.</param>
        /// <param name="parameters">Optional array of SqlParameter objects.</param>
        /// <returns>The scalar value returned by the query, or null if an error occurs.</returns>
        public static object ExecuteScalar(string query, SqlParameter[] parameters = null)
        {
            object result = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        if (parameters != null)
                        {
                            command.Parameters.AddRange(parameters);
                        }
                        result = command.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                // Display user-friendly error message
                MessageBox.Show($"Database Error (Scalar): {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Log the full exception for debugging
                Console.WriteLine($"Database Error (Scalar): {ex.Message}\n{ex.StackTrace}");
            }
            return result;
        }
    }
}
