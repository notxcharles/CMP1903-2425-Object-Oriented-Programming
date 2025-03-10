using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;

namespace linq_workshop
{
    class Program
    {
        static void Main(string[] args)
        {
            // Specify the path to the CSV file
            string filePath = "books.csv";

            // TODO #1: Create an instance of BookCollection and load books from the file
            // ===========================================================================

            BookCollection bookCollection = new BookCollection(filePath);

            // TODO #2: Display the loaded books
            // =====================================

            //foreach (var book in bookCollection.Books)
            //{
            //    Console.WriteLine($"{book}");
            //}

            //// Get book belonging to "George Orwell"
            //string authorName = "George Orwell";
            //var booksByAuthor = bookCollection.GetBooksByAuthor(authorName);
            //Console.WriteLine($"\nBooks by {authorName}:");
            //foreach (var book in booksByAuthor)
            //{
            //    Console.WriteLine(book);
            //}

            // Get books by title keyword
            string titleKeyword = "Sun";
            var booksByTitle = bookCollection.GetBooksByTitle(titleKeyword);
            Console.WriteLine($"\nBooks with title containing '{titleKeyword}':");
            foreach (var book in booksByTitle)
            {
                Console.WriteLine(book);
            }

            //// Get the book with the longest title
            //var longestTitleBook = bookCollection.GetBookWithLongestTitle();
            //Console.WriteLine("\nBook with the longest title:");
            //Console.WriteLine(longestTitleBook);

            //// Group books by author and display the count
            //var booksGroupedByAuthor = bookCollection.GroupBooksByAuthor();
            //Console.WriteLine("\nBooks grouped by author:");
            //foreach (var group in booksGroupedByAuthor)
            //{
            //    Console.WriteLine($"Author: {group.Author}, Book Count: {group.BookCount}");
            //}

        }

    }

}
