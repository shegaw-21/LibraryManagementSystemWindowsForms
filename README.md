MyLibrary - Desktop Application

This C# WinForms application, "MyLibrary," is a desktop solution designed for managing a small library's book inventory and member borrowing records. It serves as a practical project to reinforce event-driven programming concepts, UI design using WinForms, and robust database connectivity with ADO.NET.
 Overview

The application provides a comprehensive system for library staff to manage books, borrowers, and borrowing transactions efficiently. It includes user authentication and various management modules accessible through a main interface.
 Features
Login Form: Simple authentication using a username and password against a `Users` table in the database.   
  Provides clear error messages for invalid credentials.
Main Window (ManageForm): A central hub with navigation to different management sections.
Books Management: Displays a list of all books (BookID, Title, Author, ISBN, PublicationYear, TotalCopies, AvailableCopies) in a `DataGridView`.  
  CRUD Operations: Allows adding new books, editing existing book details, and deleting books.    Input Validation:Ensures required fields are not empty, numeric fields are valid, and ISBN is unique.    \
Search & Filter: Enables searching books by Title, Author, or ISBN.
Borrowers Management: Displays a list of all registered borrowers (BorrowerID, Name, Email, Phone) in a `DataGridView`.  
  CRUD Operations: Supports adding new borrowers, editing their details, and deleting borrower records.    
Input Validation: Validates non-empty fields, and ensures a basic email format.  
 Search & Filter: Allows searching borrowers by Name, Email, or Phone.
Issue/Return Books: Facilitates the process of issuing books to borrowers and recording return dates.    
Automatically decrements `AvailableCopies` when a book is issued and increments it upon return.     Records transactions in the `BorrowedBooks` table (BookID, BorrowerID, BorrowDate, DueDate, ReturnDate).
Reports: Generates a simple report listing all currently overdue books (where `DueDate` is before today's date and `ReturnDate` is NULL).
Technical Requirements
Language & Framework: C# with .NET (WinForms)
.Database: Designed for SQL Server (LocalDB is acceptable), but compatible with MySQL or SQLite (connection string adjustments may be needed).
Data Access: ADO.NET with parameterized queries for secure and efficient database operations.* Event Handling: Extensive use of event handlers for UI controls (e.g., `Click`, `TextChanged`, `FormClosing`).Exception Handling: Implements `try-catch` blocks around all database calls to provide user-friendly error messages.
Input Validation: Comprehensive validation to ensure data integrity (e.g., non-empty text boxes, numeric ranges, email format).

Project Structure

MyLibraryWindowsForms/ ├── Data/ │ └── DbHelper.cs 
 Helper class for database operations ├── Forms/ │ ├── BookManagementForm.cs 
 UI and logic for managing books │ ├── BorrowerManagementForm.cs 
 UI and logic for managing borrowers │ ├── InputForm.cs 
 Generic form for adding/editing records │ ├── IssueReturnForm.cs 
 UI and logic for issuing/returning books │ ├── LoginForm.cs 
UI and logic for user authentication │ ├── ManageForm.cs 
Main application window with navigation │ └── ReportsForm.cs 
 UI and logic for generating reports ├── Program.cs 
 Application entry point ├── App.config 
 Application configuration (connection string) └── ... (other project files)

Setup and Installation

To get this project up and running on a local machine, follow these steps:

 1. Database Setup

This project uses a SQL Server database named `MyLibraryDB`.

Prerequisites: Ensure SQL Server (e.g., SQL Server Express, LocalDB) is installed on the machine.
Create Database and Tables:
Open SQL Server Management Studio (SSMS) or Azure Data Studio.
Connect to the SQL Server instance.
Open a new query window.
Execute the SQL script provided in `A.sql` (this file should be created in the repository, or the script copied directly). This script will create the `MyLibraryDB` database, all necessary tables (`Users`, `Books`, `Borrowers`, `BorrowedBooks`), and seed them with sample data.

   `A.sql` Content (Example - ensure this file is in the repository):
    ```sql
    -- SQL Script for MyLibraryDB

    -- 1. Create the Database
    USE master;
    GO
    IF DB_ID('MyLibraryDB') IS NOT NULL
        DROP DATABASE MyLibraryDB;
    GO
    CREATE DATABASE MyLibraryDB;
    GO

    -- Use the newly created database
    USE MyLibraryDB;
    GO

    -- 2. Create Tables
    CREATE TABLE Users (
        UserID INT PRIMARY KEY IDENTITY(1,1),
        Username NVARCHAR(50) NOT NULL UNIQUE,
        PasswordHash NVARCHAR(256) NOT NULL -- Store hashed passwords, not plain text!
    );
    GO

    CREATE TABLE Books (
        BookID INT PRIMARY KEY IDENTITY(1,1),
        Title NVARCHAR(200) NOT NULL,
        Author NVARCHAR(100) NOT NULL,
        ISBN NVARCHAR(20) UNIQUE,
        PublicationYear INT,
        TotalCopies INT NOT NULL DEFAULT 0,
        AvailableCopies INT NOT NULL DEFAULT 0
    );
    GO

    CREATE TABLE Borrowers (
        BorrowerID INT PRIMARY KEY IDENTITY(1,1),
        Name NVARCHAR(100) NOT NULL,
        Email NVARCHAR(100) UNIQUE,
        Phone NVARCHAR(20)
    );
    GO

    CREATE TABLE BorrowedBooks (
        BorrowedID INT PRIMARY KEY IDENTITY(1,1),
        BookID INT NOT NULL,
        BorrowerID INT NOT NULL,
        BorrowDate DATETIME NOT NULL DEFAULT GETDATE(),
        DueDate DATETIME NOT NULL,
        ReturnDate DATETIME, -- NULL if not yet returned
        FOREIGN KEY (BookID) REFERENCES Books(BookID),
        FOREIGN KEY (BorrowerID) REFERENCES Borrowers(BorrowerID)
    );
    GO

    -- 3. Seed Sample Data
    INSERT INTO Users (Username, PasswordHash) VALUES
    ('admin', 'password_hash_for_admin'), -- In a real app, hash this password!
    ('user1', 'password_hash_for_user1');
    GO

    INSERT INTO Books (Title, Author, ISBN, PublicationYear, TotalCopies, AvailableCopies) VALUES
    ('The Great Gatsby', 'F. Scott Fitzgerald', '978-0743273565', 1925, 5, 5),
    ('1984', 'George Orwell', '978-0451524935', 1949, 3, 3),
    ('To Kill a Mockingbird', 'Harper Lee', '978-0061120084', 1960, 4, 4);
    GO

    INSERT INTO Borrowers (Name, Email, Phone) VALUES
    ('John Doe', 'john.doe@example.com', '111-222-3333'),
    ('Jane Smith', 'jane.smith@example.com', '444-555-6666');
    GO

    INSERT INTO BorrowedBooks (BookID, BorrowerID, BorrowDate, DueDate, ReturnDate) VALUES
    ((SELECT BookID FROM Books WHERE Title = 'The Great Gatsby'), (SELECT BorrowerID FROM Borrowers WHERE Name = 'John Doe'), '2025-05-01', '2025-05-15', '2025-05-10'),
    ((SELECT BookID FROM Books WHERE Title = '1984'), (SELECT BorrowerID FROM Borrowers WHERE Name = 'Jane Smith'), '2025-05-10', '2025-05-24', NULL);
    GO

    UPDATE Books
    SET AvailableCopies = TotalCopies - (SELECT COUNT(*) FROM BorrowedBooks WHERE BookID = Books.BookID AND ReturnDate IS NULL);
    GO
    ```

2. Application Configuration

Open `App.config` in the Visual Studio project.
Ensure the connection string matches the database setup. Locate the `connectionString` variable in `DbHelper.cs` and verify the `Data Source` matches the SQL Server instance name.
    ```csharp
    // In DbHelper.cs
    private static readonly string connectionString =
        "Data Source=DESKTOP-S59KTFH;Initial Catalog=MyLibraryDB;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;";
    ```
    IMPORTANT: Replace `DESKTOP-S59KTFH` with the actual SQL Server instance name.

3. Build and Run

 Open the `MyLibraryWindowsForms.sln` file in Visual Studio.
 In the Solution Explorer, right-click on the project (`MyLibraryWindowsForms`) and select "Rebuild"
Once the build is successful, press `F5` or click the "Start" button in Visual Studio to run the application.

How to Use the Application

1.  Login:
     The application will start with the Login Form.
     Enter the default credentials (see below) to log in.
2.  Main Management (ManageForm):
     After successful login, the main management window will be displayed.
    Click on the respective buttons to navigate to:
        Book Management: To add, edit, delete, and view books.
        Borrower Management:To add, edit, delete, and view borrowers.
        Issue/Return Books: To record book borrowing and returning.
        Reports:To view overdue book reports.
3.  Individual Management Forms:
     Within "Book Management" and "Borrower Management," use the "Add," "Edit," and "Delete" buttons to perform CRUD operations.
     Use the search boxes to filter records.
     Click "Back" to return to the Main Management window.
4.  Issue/Return Form:
    Select an available book from the top grid.
     Select a borrower from the middle grid.
     Click "Issue Book."
     To return a book, select a record from the "Currently Borrowed Books" grid and click "Return Book."
5.  Reports Form:
    The form will automatically display overdue books on load.
    Click "Generate Report" to refresh the list.

Default Login Credentials

For testing purposes, the following credentials can be used:

Username:`admin`
Password: `1234` (Note: In a real application, this would be a securely hashed password. For this assignment, it's a plain string for simplicity.)
 UI Screenshots

Key screen captures of the application's user interface are available in the `/docs/screenshots/` folder within this repository.

 `Login Form.png`
 `Main Window.png`
 `Book Management.png`
`Borrower Management.png`
`Issue-Return Flows.png`
`Overdue Reports.png`


Author:

SHEGAW AFELE DBU1501469
