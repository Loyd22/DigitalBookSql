using System;
using System.Collections.Generic;
using digiBookModel;
using digiBookBusiness;

namespace Digibook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Business bookService = new Business();

            List<bookss> books = bookService.GetAllBooks();

            if (books.Count > 0)
            {
                Console.WriteLine("Available books:");
                for (int i = 0; i < books.Count; i++)
                {
                    Console.WriteLine($"{i + 1}: {books[i].title}");
                }

                Console.Write("Enter the number of the book you want to select: ");
                if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= books.Count)
                {
                    bookss selectedBook = books[choice - 1];
                    Console.WriteLine($"You have selected: {selectedBook.title} by {selectedBook.author}");
                    Console.WriteLine($"Summary: {selectedBook.summary}");
                }
                else
                {
                    Console.WriteLine("Invalid selection.");
                }
            }
            else
            {
                Console.WriteLine("No books available.");
            }
        }
    }
}

