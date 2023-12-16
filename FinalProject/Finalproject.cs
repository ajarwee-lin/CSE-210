using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Example usage of the Library Management System
        Library library = new Library();

        Book book1 = new Book("The Catcher in the Rye", "J.D. Salinger", "12345");
        Book book2 = new Book("To Kill a Mockingbird", "Harper Lee", "67890");

        library.AddBook(book1);
        library.AddBook(book2);

        Member member1 = new Member("M001", "John Doe");
        Member member2 = new Member("M002", "Jane Smith");

        library.AddMember(member1);
        library.AddMember(member2);

        library.DisplayBooks();
        library.DisplayMembers();

        // Simulate a book transaction
        library.BorrowBook(book1, member1);
        library.DisplayBooks();
        library.DisplayMembers();

        library.ReturnBook(book1);
        library.DisplayBooks();
        library.DisplayMembers();
    }
}

class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public bool IsAvailable { get; set; } = true;

    public Book(string title, string author, string isbn)
    {
        Title = title;
        Author = author;
        ISBN = isbn;
    }
}

class Member
{
    public string MemberID { get; set; }
    public string Name { get; set; }
    public List<Book> BorrowedBooks { get; set; } = new List<Book>();

    public Member(string memberID, string name)
    {
        MemberID = memberID;
        Name = name;
    }
}

class Library
{
    private List<Book> books = new List<Book>();
    private List<Member> members = new List<Member>();

    public void AddBook(Book book)
    {
        books.Add(book);
    }

    public void AddMember(Member member)
    {
        members.Add(member);
    }

    public void BorrowBook(Book book, Member member)
    {
        if (book.IsAvailable)
        {
            book.IsAvailable = false;
            member.BorrowedBooks.Add(book);
            Console.WriteLine($"{member.Name} borrowed {book.Title}.");
        }
        else
        {
            Console.WriteLine($"{book.Title} is not available for borrowing.");
        }
    }

    public void ReturnBook(Book book)
    {
        if (!book.IsAvailable)
        {
            book.IsAvailable = true;
            Console.WriteLine($"Book {book.Title} returned.");
        }
        else
        {
            Console.WriteLine($"Error: Book {book.Title} is already available.");
        }
    }

    public void DisplayBooks()
    {
        Console.WriteLine("\nLibrary Books:");
        foreach (var book in books)
        {
            Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, ISBN: {book.ISBN}, Available: {book.IsAvailable}");
        }
    }

    public void DisplayMembers()
    {
        Console.WriteLine("\nLibrary Members:");
        foreach (var member in members)
        {
            Console.WriteLine($"MemberID: {member.MemberID}, Name: {member.Name}, Borrowed Books: {member.BorrowedBooks.Count}");
        }
    }
}
