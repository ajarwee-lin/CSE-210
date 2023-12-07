using System;
using System.Collections.Generic;

// Book Class
public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public bool IsAvailable { get; set; }

    public void CheckOut()
    {
        IsAvailable = false;
    }

    public void CheckIn()
    {
        IsAvailable = true;
    }
}

// LibraryMember Class
public class LibraryMember
{
    public int MemberID { get; set; }
    public string Name { get; set; }
    public List<Transaction> BorrowingHistory { get; set; }

    public LibraryMember()
    {
        BorrowingHistory = new List<Transaction>();
    }

    public void BorrowBook(Book book)
    {
        Transaction transaction = new Transaction(this, book);
        BorrowingHistory.Add(transaction);
    }

    public void ReturnBook(Transaction transaction)
    {
        transaction.CompleteTransaction();
    }
}

// Transaction Class
public class Transaction
{
    public Book Book { get; set; }
    public LibraryMember Member { get; set; }
    public DateTime IssueDate { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsReturned { get; set; }
    public double Fine { get; set; }

    public Transaction(LibraryMember member, Book book)
    {
        Member = member;
        Book = book;
        IssueDate = DateTime.Now;
        DueDate = IssueDate.AddDays(14); // Assuming a 14-day borrowing period
        IsReturned = false;
        Fine = 0;
    }

    public void CalculateFine()
    {
        if (DateTime.Now > DueDate && !IsReturned)
        {
            // Calculate fine logic (you can customize this based on your requirements)
            TimeSpan overdue = DateTime.Now - DueDate;
            Fine = overdue.Days * 0.5; // Assuming a fixed fine of $0.50 per day
        }
    }

    public void CompleteTransaction()
    {
        if (!IsReturned)
        {
            CalculateFine();
            Book.CheckIn();
            IsReturned = true;
        }
    }
}

// Example Program Execution Flow
class Program
{
    static void Main()
    {
        // Initialization
        Book book1 = new Book { Title = "Book1", Author = "Author1", IsAvailable = true };
        Book book2 = new Book { Title = "Book2", Author = "Author2", IsAvailable = true };

        LibraryMember member1 = new LibraryMember { MemberID = 1, Name = "Member1" };

        // Transaction Initiation
        member1.BorrowBook(book1);

        // Fine Calculation
        Transaction transaction = member1.BorrowingHistory[0];
        transaction.CalculateFine();

        // Transaction Completion
        member1.ReturnBook(transaction);
    }
}
