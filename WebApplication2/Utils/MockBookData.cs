using System.Collections.Generic;
using System.Linq;
using WebApplication2.Models;
using WebApplication2.Utils;

namespace WebApplication2.bookData
{
    /*public class MockBookData : IbookData
    {
        private List<Book> books = new List<Book>()
        {
            new Book()
            {
                id = 1,
                publisher = "publisher one",
                title = "title one ",
                author ="author one"
            },
             new Book()
            {
                id = 2,
                publisher = "publisher two",
                title = "title two ",
                author ="author two"
            }
        };

        public Book AddBook(Book book)
        {
            books.Add(book);
            return book;
        }

        public void DeleteBook(Book book)
        {
            books.Remove(book);
        }

        public List<Book> GetBooks()
        {
            return books;
        }

        public Book GetBook(int id)
        {
            return books.Find(book => book.id == id);
        }

        public List<Book> GetBookByAuthor(string author)
        {
            return books.FindAll(b => b.author == author).ToList();
        }

        public Book GetBookByTitle(string title)
        {
            return books.Find(b => b.title == title);
        }

        public List<Book> GetBookByPublisher(string publisher)
        {
            return books.FindAll(b => b.publisher == publisher).ToList();
        }

        public Book UpdateBook(Book book)
        {
            var currentBook = GetBook(book.id);
            currentBook.title = book.title;
            currentBook.author = book.author;
            currentBook.publisher = book.publisher;
            return currentBook;
        }

    }*/
}
