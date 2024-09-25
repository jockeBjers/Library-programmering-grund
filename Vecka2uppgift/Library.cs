using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vecka2uppgift
{
    public class Library
    {
        private static Dictionary<long, Book> books = new();

        
        public static void PrintAllBooks()
        {
            Console.Clear(); 
            var sortedBooks = books
            .OrderBy(book => book.Value.CopiesAvailable); // Sorting based on copies available
            foreach (var book in sortedBooks)
            {
                Console.WriteLine($"ISBN: {book.Key}, Title: {book.Value.Title}, Author: {book.Value.Author}, Copies: {book.Value.CopiesAvailable}");
            }
        }

        
        public static void AddBook(string title, string author, long isbn, int copies)
        {
            if (books.Values.Any(b => b.ISBN == isbn)) // looking for matching isbn
            {
                //if isbn already exist, it returns without adding a book
                Console.WriteLine("A book with this ISBN already exists.");
                return;
            }
            var newBook = new Book { Title = title, Author = author, ISBN = isbn, CopiesAvailable = copies };
            books[isbn] = newBook; // The ISBN is added as the key!
            Console.WriteLine($"Book '{title}' added with ISBN {isbn}.");
        }

        public static void RemoveBook(long isbn) 
        {
            if (books.Remove(isbn)) //If isbn matching, remeove book
            {
                Console.WriteLine($"Book with ISBN: {isbn} has been removed.");
            }
            else // Otherwise print a message that no such book exists.
            {
                Console.WriteLine("No book found with that ISBN.");
            }
        }

        
        public static Book? FindBookByISBN(long isbn) //if no book found, null is returned
        {
            // returning found book to the method to continue to next method to modify the content 
            return books.Values.FirstOrDefault(b => b.ISBN == isbn);
        }

        public static void ModifyBookQuantity(Book book, int choice, int? newTotal = null) //The newTotal is optional
        {
            switch (choice)
            {
                case 1: // increment amount of copies by 1
                    book.CopiesAvailable++;
                    Console.WriteLine($"A copy has been added. Updated Copies Available = {book.CopiesAvailable}");
                    break;
                case 2: // decrement by 1
                    if (book.CopiesAvailable > 0)
                    {
                        book.CopiesAvailable--;
                        Console.WriteLine($"A copy has been removed. Updated Copies Available = {book.CopiesAvailable}");
                    }
                    else // Else lower than one it wont go negative
                    {
                        Console.WriteLine("No copies available to remove.");
                    }
                    break;
                case 3: // Set a new total for book
                    if (newTotal.HasValue && newTotal >= 0)
                    {
                        book.CopiesAvailable = newTotal.Value;
                        Console.WriteLine($"Copies have been updated. New Copies Available = {book.CopiesAvailable}");
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid non-negative number.");
                    }
                    break;
                default:
                    Console.WriteLine("Invalid option selected.");
                    break;
            }
        }
    }
}