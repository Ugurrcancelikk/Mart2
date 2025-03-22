using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Library library = new Library();
        library.SeedData();  // Örnek verileri ekleyelim

        while (true)
        {
            Console.WriteLine("\n--- Kütüphane Sistemi ---");
            Console.WriteLine("1. Kitapları Listele");
            Console.WriteLine("2. Kitap Ödünç Al");
            Console.WriteLine("3. Kitap Teslim Et");
            Console.WriteLine("4. Çıkış");
            Console.Write("Seçiminizi yapın: ");
            
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    library.ListBooks();
                    break;
                case "2":
                    library.BorrowBook();
                    break;
                case "3":
                    library.ReturnBook();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Geçersiz seçim, tekrar deneyin.");
                    break;
            }
        }
    }
}