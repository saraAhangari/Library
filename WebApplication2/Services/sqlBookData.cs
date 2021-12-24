using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using WebApplication2.Models;
using WebApplication2.ModelsDTO;

namespace WebApplication2.Utils
{
    public class sqlBookData : IBookData
    {
        private LibraryContext _bookContext;
        bool foundPub = false;
        bool foundAuth = false;
        public sqlBookData(LibraryContext bookContext)
        {
            this._bookContext = bookContext;
        }
        public void AddBook(BookDTO dto)
        {
            Book book = new Book();
            book.title = dto.title;


            Publisher publisher = new Publisher();
            publisher.Name = dto.publisher.Name;
            publisher.book.Add(book);
            foreach(var pub in _bookContext.Publishers)
            {
                if (pub.Name == publisher.Name)
                {
                    foundPub = true;
                    publisher = pub;
                    break;
                }
            }
            if (foundPub)
                book.publisher.Add(publisher);
            else
                _bookContext.Publishers.Add(publisher);


            foreach (var author in dto.authors)
            {
                Author bookauthor = new Author();
                bookauthor.Firstname = author.Firstname;
                bookauthor.Lastname = author.Lastname;
                bookauthor.AuthorContact = author.details;
                bookauthor.Books.Add(book);
                foreach (var author2 in _bookContext.Authors)
                {
                    if(author2.Firstname.Equals(bookauthor.Firstname)
                        && author2.Lastname.Equals(bookauthor.Lastname))
                    {
                        foundAuth = true;
                        bookauthor = author2;
                        break;
                    }
                }
                if (foundAuth)
                    book.authors.Add(bookauthor);  
                else
                    _bookContext.Authors.Add(bookauthor);
            }
            _bookContext.Books.Add(book);
            _bookContext.SaveChanges();
        }

        public Book UpdateBook(BookUpdateDTO book)
        {
            var currentBook = _bookContext.Books.Find(book.Id);
            if (currentBook != null)
            {
                currentBook.title = book.title;

                Publisher publisher = new Publisher();
                publisher.Name = book.publisher.Name;
                //currentBook.publisher.Add(publisher);

                foreach (var author in book.authors)
                {
                    Author bookauthor = new Author();
                    bookauthor.Firstname = author.Firstname;
                    bookauthor.Lastname= author.Lastname;
                    bookauthor.AuthorContact= author.details;
                    currentBook.authors.Add(bookauthor);
                }
                _bookContext.Books.Update(currentBook);
                _bookContext.SaveChanges();
            }
            return currentBook;
        }

        public void DeleteBook(Book book)
        {
            _bookContext.Books.Remove(book);
            _bookContext.SaveChanges();
        }

        public Book GetBook(int id)
        {
            return _bookContext.Books.SingleOrDefault(b => b.Id == id);
        }

        //public List<Book> GetBookByAuthor(Author author)
        //{
        //    //return _bookContext.Books.Where(b => b.authorsList.Contains(author)).ToList();
        //}

        //public List<Book> GetBookByPublisher(Publisher publisher)
        //{
        //    //return _bookContext.Books.Where(b => b.publisher == publisher).ToList();
        //}

        public Book GetBookByTitle(string title)
        {
            return _bookContext.Books.SingleOrDefault(b => b.title == title);
        }

        public List<Book> GetBooks()
        {
            return _bookContext.Books.ToList();
        }

        
    }
}
