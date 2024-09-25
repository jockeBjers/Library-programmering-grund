using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Vecka2uppgift
{
    public class BookInterface
    {
        public static void Menu() 
        {
            InitializeBooks();
            Console.Clear();
            while (true)
            {
                int input = InputHelper.GetUserInput<int>("Press:\n1. List all books\n2. Add a book\n" +
                    "3. Remove a book\n4. Find a book by ISBN\n5. Exit"); 
                switch (input)
                {
                    case 1:
                        Library.PrintAllBooks(); 
                        break;
                    case 2:
                        AddBook(); 
                        break;
                    case 3:
                        RemoveBook(); 
                        break;
                    case 4:
                        FindBook(); 
                        break;
                    case 5:
                        Program.CloseProgram(); 
                        break;
                    default:
                        Console.WriteLine("That number doesn't exist.");
                        break;
                } // end switch
            }
        }

        private static void AddBook() 
        {
            Console.Clear();
            while (true)
            {
                // Getting user inpuit
                string title = InputHelper.GetUserInput<string>("Enter book title:");
                string author = InputHelper.GetUserInput<string>("Enter author:");
                long isbn;
                // Checks for the lenght of the isbn, if it isnt 13 digits long it will loop again
                while ((isbn = InputHelper.GetUserInput<long>("Enter the ISBN code (13 digits):")).ToString().Length != 13)
                {
                    Console.WriteLine("Invalid ISBN! ISBN must be exactly 13 digits. Please try again.");
                }
                int copies = InputHelper.GetUserInput<int>("Enter the number of copies:");
                Library.AddBook(title, author, isbn, copies); //adding book to the library
                // ask if user want to add another book
                if (!InputHelper.GetConfirmation("Would you like to continue adding Books?"))
                {
                    break; // Exit loop and go back to menu
                }
            }
        }

        private static void RemoveBook() 
        {
            Console.Clear();
            while (true)
            {
                long isbn = InputHelper.GetUserInput<long>("Enter the ISBN of the book to remove:");
                Library.RemoveBook(isbn); //Removes a book if isbn match
                //ask if user want to remove another book
                if (!InputHelper.GetConfirmation("Would you like to remove another book?"))
                {
                    break; // Exit loop and go back to menu
                }
            }
        }

        private static void FindBook() //search for book by isbn(key) and alter the amount of copies
        {
            Console.Clear();
            long isbn = InputHelper.GetUserInput<long>("Enter the ISBN of the book you want to search for: ");
            Book? foundBook = Library.FindBookByISBN(isbn); // try to match book by isbn
            if (foundBook != null)
            {
                // if found, details are printed in the console.
                Console.WriteLine($"Book found: ISBN = {foundBook.ISBN}, Title = {foundBook.Title}" +
                    $", Author = {foundBook.Author}, Copies Available = {foundBook.CopiesAvailable}\n");
                ModifyBook(foundBook); // continues in the program to alter the quantity
            }
            else
            {
                Console.WriteLine("No book found with that ISBN.");
            }
        }

        private static void ModifyBook(Book book) //ask user what to do with found book
        {
            while (true)
            {
                int choice = InputHelper.GetUserInput<int>("What would you like to do?\n1. Add a copy\n" +
                    "2. Remove a copy\n3. Set a new number of copies\n4. Go back to the menu  "); //Get user choice

                if (choice == 3)
                {
                    //If set a new number of copies, takes in a newTotal input aswell
                    int newTotal = InputHelper.GetUserInput<int>("Enter the new total number of copies:");
                    Library.ModifyBookQuantity(book, choice, newTotal);
                }
                else if (choice == 4)
                {
                    break; // Return to the main menu
                }
                else
                {
                    // else if 1 or 2, it will increment or decrement amount by one.
                    Library.ModifyBookQuantity(book, choice);
                }
                // Option to modify again or go back
                if (!InputHelper.GetConfirmation("Would you like to modify something else for this book?"))
                {
                    break; // Exit loop and go back to menu
                }
            }
        }

        public static void InitializeBooks()
        {
            // Initialize predefined books to emulate a database
            Library.AddBook("Dinosaurs", "Joakim Bjerselius", 9780743242424, 22);
            Library.AddBook("The Bible", "Unknown Entity", 9780743233222, 10);
            Library.AddBook("The not so Great Wall of China", "Kim Jong Un", 9780743273565, 500);
            Library.AddBook("Wallpapers", "Henry Ford", 9780743272234, 14);
            Library.AddBook("The sea and the lamb", "Ken B Benny", 9780743274144, 20);
        }
    }
}