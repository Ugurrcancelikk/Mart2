using System;
using System.Collections.Generic;
using System.Linq;
using Mart2;

class Library
{
    private List<Book> Books = new List<Book>();
    private List<Student> Students = new List<Student>();
    private List<Loan> Loans = new List<Loan>();

    public void SeedData()
    {
        Students.Add(new Student { StudentId = 1, FullName = "Ali Veli", Email = "ali@example.com" });

        Books.Add(new Book { BookId = 1, Title = "C# Programlama", Author = "John Doe", Category = "Programlama", IsAvailable = true });
        Books.Add(new Book { BookId = 2, Title = "Veri Yapıları", Author = "Jane Doe", Category = "Bilgisayar Bilimleri", IsAvailable = true });

        Console.WriteLine("Örnek veriler eklendi.");
    }

    public void ListBooks()
    {
        Console.WriteLine("\n--- Mevcut Kitaplar ---");
        foreach (var book in Books)
        {
            string status = book.IsAvailable ? "Mevcut" : "Ödünç Alındı";
            Console.WriteLine($"{book.BookId}. {book.Title} - {book.Author} ({book.Category}) [{status}]");
        }
    }

    public void BorrowBook()
    {
        Console.Write("Öğrenci ID girin: ");
        int studentId = int.Parse(Console.ReadLine());

        var student = Students.FirstOrDefault(s => s.StudentId == studentId);
        if (student == null)
        {
            Console.WriteLine("Öğrenci bulunamadı.");
            return;
        }

        Console.Write("Ödünç almak istediğiniz kitabın ID'sini girin: ");
        int bookId = int.Parse(Console.ReadLine());

        var book = Books.FirstOrDefault(b => b.BookId == bookId && b.IsAvailable);
        if (book == null)
        {
            Console.WriteLine("Kitap bulunamadı veya şu an ödünç alınmış.");
            return;
        }

        book.IsAvailable = false;
        Loans.Add(new Loan { LoanId = Loans.Count + 1, Student = student, Book = book, LoanDate = DateTime.Now });
        Console.WriteLine($"{student.FullName}, '{book.Title}' kitabını ödünç aldı.");
    }

    public void ReturnBook()
    {
        Console.Write("Teslim etmek istediğiniz kitabın ID'sini girin: ");
        int bookId = int.Parse(Console.ReadLine());

        var loan = Loans.FirstOrDefault(l => l.Book.BookId == bookId);
        if (loan == null)
        {
            Console.WriteLine("Kitap ödünç alınmamış.");
            return;
        }

        loan.Book.IsAvailable = true;
        Loans.Remove(loan);
        Console.WriteLine($"'{loan.Book.Title}' kitabı başarıyla teslim edildi.");
    }
}
