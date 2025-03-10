using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace linq_workshop
{
    public class BookCollection
    {
        public List<Book> Books { get; private set; }

        // Constructor that accepts a filename to load books from the file
        public BookCollection(string filename)
        {
            Books = new List<Book>();
            LoadBooksFromFile(filename);
        }

        // Method to load books from the CSV file
        private void LoadBooksFromFile(string filename)
        {
            // Read all lines from the file
            var lines = File.ReadAllLines(filename);

            // Iterate over each line and create a new Book object
            foreach (var line in lines)
            {
                var details = line.Split(','); // Assuming CSV format: Title, Author, ISBN
                if (details.Length == 3)
                {
                    var book = new Book(details[0], details[1], details[2]);
                    Books.Add(book);
                }
            }
        }

        // Method to get all books by a specific author
        public List<Book> GetBooksByAuthor(string author)
        {
            // TODO #3: mplement the LINQ to get all books by a specific author
            List<Book> books;
            books = (from book in Books where book.Author == author select book).ToList();
            return books;
        }

        // Method to get all books containing a specific keyword in the title
        public List<Book> GetBooksByTitle(string keyword)
        {
            // TODO #4: mplement the LINQ to get all books containing a specific keyword in the title
            List<Book> books;
            books = (from book in Books where book.Title.Contains(keyword) select book).ToList();
            return books;
        }

        // Method to get the book with the longest title in the collection
        public Book GetBookWithLongestTitle()
        {
            // TODO #5: mplement the LINQ to get the book with the longest title in the collection
            Book longestBook = Books.OrderByDescending(book => book.Title.Length).First();
            return longestBook;
        }

        //// Method to group books by author and count the number of books per author
        //public List<(string Author, int BookCount)> GroupBooksByAuthor()
        //{
        //    // TODO #6: Implement the LINQ to group books by author and count the number of books per author 



        //}
    }
}
