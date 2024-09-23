using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vecka2uppgift
{
    public class Book
    {
        // Properties for the book
        public required string Title { get; set; }
        public required string Author { get; set; }
        public int CopiesAvailable { get; set; }
        public long ISBN { get; set; }
        public Book() //Empty constructor to create through input
        {

        }

        // Constructor to initialize the book.
        public Book(string title, string author, long isbn, int copiesAvailable)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            CopiesAvailable = copiesAvailable;
        }
    }
}