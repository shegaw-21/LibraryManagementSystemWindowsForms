// IssueReturnForm.Designer.cs
namespace LibraryWindowsForms
{
    partial class IssueReturnForm
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.groupBoxAvailableBooks = new System.Windows.Forms.GroupBox();
            this.txtSearchAvailableBooks = new System.Windows.Forms.TextBox();
            this.lblSearchAvailableBooks = new System.Windows.Forms.Label();
            this.dataGridViewAvailableBooks = new System.Windows.Forms.DataGridView();
            this.groupBoxBorrowers = new System.Windows.Forms.GroupBox();
            this.txtSearchBorrowers = new System.Windows.Forms.TextBox();
            this.lblSearchBorrowers = new System.Windows.Forms.Label();
            this.dataGridViewBorrowers = new System.Windows.Forms.DataGridView();
            this.btnIssueBook = new System.Windows.Forms.Button();
            this.btnReturnBook = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.groupBoxBorrowedBooks = new System.Windows.Forms.GroupBox();
            this.txtSearchBorrowedBooks = new System.Windows.Forms.TextBox();
            this.lblSearchBorrowedBooks = new System.Windows.Forms.Label();
            this.dataGridViewBorrowedBooks = new System.Windows.Forms.DataGridView();
            this.groupBoxAvailableBooks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAvailableBooks)).BeginInit();
            this.groupBoxBorrowers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBorrowers)).BeginInit();
            this.groupBoxBorrowedBooks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBorrowedBooks)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(253, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Issue and Return Books";
            // 
            // groupBoxAvailableBooks
            // 
            this.groupBoxAvailableBooks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxAvailableBooks.Controls.Add(this.txtSearchAvailableBooks);
            this.groupBoxAvailableBooks.Controls.Add(this.lblSearchAvailableBooks);
            this.groupBoxAvailableBooks.Controls.Add(this.dataGridViewAvailableBooks);
            this.groupBoxAvailableBooks.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxAvailableBooks.Location = new System.Drawing.Point(20, 70);
            this.groupBoxAvailableBooks.Name = "groupBoxAvailableBooks";
            this.groupBoxAvailableBooks.Size = new System.Drawing.Size(940, 200);
            this.groupBoxAvailableBooks.TabIndex = 1;
            this.groupBoxAvailableBooks.TabStop = false;
            this.groupBoxAvailableBooks.Text = "Available Books";
            // 
            // txtSearchAvailableBooks
            // 
            this.txtSearchAvailableBooks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchAvailableBooks.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchAvailableBooks.Location = new System.Drawing.Point(740, 25);
            this.txtSearchAvailableBooks.Name = "txtSearchAvailableBooks";
            this.txtSearchAvailableBooks.Size = new System.Drawing.Size(180, 23);
            this.txtSearchAvailableBooks.TabIndex = 2;
            this.txtSearchAvailableBooks.TextChanged += new System.EventHandler(this.txtSearchAvailableBooks_TextChanged);
            // 
            // lblSearchAvailableBooks
            // 
            this.lblSearchAvailableBooks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSearchAvailableBooks.AutoSize = true;
            this.lblSearchAvailableBooks.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchAvailableBooks.Location = new System.Drawing.Point(690, 28);
            this.lblSearchAvailableBooks.Name = "lblSearchAvailableBooks";
            this.lblSearchAvailableBooks.Size = new System.Drawing.Size(45, 15);
            this.lblSearchAvailableBooks.TabIndex = 1;
            this.lblSearchAvailableBooks.Text = "Search:";
            // 
            // dataGridViewAvailableBooks
            // 
            this.dataGridViewAvailableBooks.AllowUserToAddRows = false;
            this.dataGridViewAvailableBooks.AllowUserToDeleteRows = false;
            this.dataGridViewAvailableBooks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewAvailableBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAvailableBooks.Location = new System.Drawing.Point(10, 55);
            this.dataGridViewAvailableBooks.MultiSelect = false;
            this.dataGridViewAvailableBooks.Name = "dataGridViewAvailableBooks";
            this.dataGridViewAvailableBooks.ReadOnly = true;
            this.dataGridViewAvailableBooks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAvailableBooks.Size = new System.Drawing.Size(920, 135);
            this.dataGridViewAvailableBooks.TabIndex = 0;
            // 
            // groupBoxBorrowers
            // 
            this.groupBoxBorrowers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxBorrowers.Controls.Add(this.txtSearchBorrowers);
            this.groupBoxBorrowers.Controls.Add(this.lblSearchBorrowers);
            this.groupBoxBorrowers.Controls.Add(this.dataGridViewBorrowers);
            this.groupBoxBorrowers.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxBorrowers.Location = new System.Drawing.Point(20, 280);
            this.groupBoxBorrowers.Name = "groupBoxBorrowers";
            this.groupBoxBorrowers.Size = new System.Drawing.Size(940, 200);
            this.groupBoxBorrowers.TabIndex = 2;
            this.groupBoxBorrowers.TabStop = false;
            this.groupBoxBorrowers.Text = "Borrowers";
            // 
            // txtSearchBorrowers
            // 
            this.txtSearchBorrowers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchBorrowers.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchBorrowers.Location = new System.Drawing.Point(740, 25);
            this.txtSearchBorrowers.Name = "txtSearchBorrowers";
            this.txtSearchBorrowers.Size = new System.Drawing.Size(180, 23);
            this.txtSearchBorrowers.TabIndex = 2;
            this.txtSearchBorrowers.TextChanged += new System.EventHandler(this.txtSearchBorrowers_TextChanged);
            // 
            // lblSearchBorrowers
            // 
            this.lblSearchBorrowers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSearchBorrowers.AutoSize = true;
            this.lblSearchBorrowers.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchBorrowers.Location = new System.Drawing.Point(690, 28);
            this.lblSearchBorrowers.Name = "lblSearchBorrowers";
            this.lblSearchBorrowers.Size = new System.Drawing.Size(45, 15);
            this.lblSearchBorrowers.TabIndex = 1;
            this.lblSearchBorrowers.Text = "Search:";
            // 
            // dataGridViewBorrowers
            // 
            this.dataGridViewBorrowers.AllowUserToAddRows = false;
            this.dataGridViewBorrowers.AllowUserToDeleteRows = false;
            this.dataGridViewBorrowers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewBorrowers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBorrowers.Location = new System.Drawing.Point(10, 55);
            this.dataGridViewBorrowers.MultiSelect = false;
            this.dataGridViewBorrowers.Name = "dataGridViewBorrowers";
            this.dataGridViewBorrowers.ReadOnly = true;
            this.dataGridViewBorrowers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewBorrowers.Size = new System.Drawing.Size(920, 135);
            this.dataGridViewBorrowers.TabIndex = 0;
            // 
            // btnIssueBook
            // 
            this.btnIssueBook.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnIssueBook.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIssueBook.Location = new System.Drawing.Point(350, 414);
            this.btnIssueBook.Name = "btnIssueBook";
            this.btnIssueBook.Size = new System.Drawing.Size(120, 40);
            this.btnIssueBook.TabIndex = 3;
            this.btnIssueBook.Text = "Issue Book";
            this.btnIssueBook.UseVisualStyleBackColor = true;
            this.btnIssueBook.Click += new System.EventHandler(this.btnIssueBook_Click);
            // 
            // btnReturnBook
            // 
            this.btnReturnBook.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnReturnBook.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturnBook.Location = new System.Drawing.Point(490, 414);
            this.btnReturnBook.Name = "btnReturnBook";
            this.btnReturnBook.Size = new System.Drawing.Size(120, 40);
            this.btnReturnBook.TabIndex = 4;
            this.btnReturnBook.Text = "Return Book";
            this.btnReturnBook.UseVisualStyleBackColor = true;
            this.btnReturnBook.Click += new System.EventHandler(this.btnReturnBook_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(880, 25);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(80, 30);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "Refresh All";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(840, 699);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(120, 40);
            this.btnBack.TabIndex = 6;
            this.btnBack.Text = "Back to Main";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // groupBoxBorrowedBooks
            // 
            this.groupBoxBorrowedBooks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxBorrowedBooks.Controls.Add(this.txtSearchBorrowedBooks);
            this.groupBoxBorrowedBooks.Controls.Add(this.lblSearchBorrowedBooks);
            this.groupBoxBorrowedBooks.Controls.Add(this.dataGridViewBorrowedBooks);
            this.groupBoxBorrowedBooks.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxBorrowedBooks.Location = new System.Drawing.Point(20, 550);
            this.groupBoxBorrowedBooks.Name = "groupBoxBorrowedBooks";
            this.groupBoxBorrowedBooks.Size = new System.Drawing.Size(940, 139);
            this.groupBoxBorrowedBooks.TabIndex = 7;
            this.groupBoxBorrowedBooks.TabStop = false;
            this.groupBoxBorrowedBooks.Text = "Currently Borrowed Books";
            // 
            // txtSearchBorrowedBooks
            // 
            this.txtSearchBorrowedBooks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchBorrowedBooks.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchBorrowedBooks.Location = new System.Drawing.Point(740, 25);
            this.txtSearchBorrowedBooks.Name = "txtSearchBorrowedBooks";
            this.txtSearchBorrowedBooks.Size = new System.Drawing.Size(180, 23);
            this.txtSearchBorrowedBooks.TabIndex = 2;
            this.txtSearchBorrowedBooks.TextChanged += new System.EventHandler(this.txtSearchBorrowedBooks_TextChanged);
            // 
            // lblSearchBorrowedBooks
            // 
            this.lblSearchBorrowedBooks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSearchBorrowedBooks.AutoSize = true;
            this.lblSearchBorrowedBooks.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchBorrowedBooks.Location = new System.Drawing.Point(690, 28);
            this.lblSearchBorrowedBooks.Name = "lblSearchBorrowedBooks";
            this.lblSearchBorrowedBooks.Size = new System.Drawing.Size(45, 15);
            this.lblSearchBorrowedBooks.TabIndex = 1;
            this.lblSearchBorrowedBooks.Text = "Search:";
            // 
            // dataGridViewBorrowedBooks
            // 
            this.dataGridViewBorrowedBooks.AllowUserToAddRows = false;
            this.dataGridViewBorrowedBooks.AllowUserToDeleteRows = false;
            this.dataGridViewBorrowedBooks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewBorrowedBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBorrowedBooks.Location = new System.Drawing.Point(10, 55);
            this.dataGridViewBorrowedBooks.MultiSelect = false;
            this.dataGridViewBorrowedBooks.Name = "dataGridViewBorrowedBooks";
            this.dataGridViewBorrowedBooks.ReadOnly = true;
            this.dataGridViewBorrowedBooks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewBorrowedBooks.Size = new System.Drawing.Size(920, 74);
            this.dataGridViewBorrowedBooks.TabIndex = 0;
            // 
            // IssueReturnForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 749);
            this.Controls.Add(this.groupBoxBorrowedBooks);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnReturnBook);
            this.Controls.Add(this.btnIssueBook);
            this.Controls.Add(this.groupBoxBorrowers);
            this.Controls.Add(this.groupBoxAvailableBooks);
            this.Controls.Add(this.lblTitle);
            this.Name = "IssueReturnForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IssueReturnForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IssueReturnForm_FormClosing);
            this.groupBoxAvailableBooks.ResumeLayout(false);
            this.groupBoxAvailableBooks.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAvailableBooks)).EndInit();
            this.groupBoxBorrowers.ResumeLayout(false);
            this.groupBoxBorrowers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBorrowers)).EndInit();
            this.groupBoxBorrowedBooks.ResumeLayout(false);
            this.groupBoxBorrowedBooks.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBorrowedBooks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox groupBoxAvailableBooks;
        private System.Windows.Forms.DataGridView dataGridViewAvailableBooks;
        private System.Windows.Forms.TextBox txtSearchAvailableBooks;
        private System.Windows.Forms.Label lblSearchAvailableBooks;
        private System.Windows.Forms.GroupBox groupBoxBorrowers;
        private System.Windows.Forms.TextBox txtSearchBorrowers;
        private System.Windows.Forms.Label lblSearchBorrowers;
        private System.Windows.Forms.DataGridView dataGridViewBorrowers;
        private System.Windows.Forms.Button btnIssueBook;
        private System.Windows.Forms.Button btnReturnBook;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.GroupBox groupBoxBorrowedBooks;
        private System.Windows.Forms.TextBox txtSearchBorrowedBooks;
        private System.Windows.Forms.Label lblSearchBorrowedBooks;
        private System.Windows.Forms.DataGridView dataGridViewBorrowedBooks;
    }
}
