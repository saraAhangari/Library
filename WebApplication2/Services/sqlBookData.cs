﻿using Microsoft.EntityFrameworkCore;
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

        public void DeleteBook(int id)
        {
            var book = _bookContext.Books.SingleOrDefault(x => x.Id == id);
            var authors = _bookContext.Authors.Include("Books")
                .Where(author => author.Books.Any(b => b.Id == book.Id)).ToList();
            foreach (var a in authors)
            {
                a.Books.Remove(book);
            }
            _bookContext.Books.Remove(book);
            _bookContext.SaveChanges();
        }

        public BookDTO GetBook(int id)
        {
            var book = _bookContext.Books.SingleOrDefault(b => b.Id == id);

            if (book != null)
            {
                BookDTO dTO = new BookDTO();
                dTO.title = book.title;

                List<Publisher> publisher = _bookContext.Publishers.Where(p => p.book.Contains(book))
                                                                    .ToList();
                List<Author> authors = _bookContext.Authors.Where(a => a.Books.Contains(book))
                                                           .ToList();
                book.publisher = publisher;
                book.authors = authors;

                foreach (var pub in book.publisher)
                {
                    PublisherDTO publisherDTO = new PublisherDTO();
                    publisherDTO.Name = pub.Name;
                    dTO.publisher = publisherDTO;
                }


                foreach (var author in book.authors)
                {
                    AuthorDTO authorDTO = new AuthorDTO();
                    authorDTO.Firstname = author.Firstname;
                    authorDTO.Lastname = author.Lastname;
                    foreach (var detail in _bookContext.AuthorContact)
                    {
                        if (detail.AuthorId == author.Id)
                            authorDTO.details = detail;
                    }
                    dTO.authors.Add(authorDTO);
                }
                return dTO;
            }
            return null;
        }

        public BookDTO GetBookByTitle(string title)
        {
            var book = _bookContext.Books.SingleOrDefault(b => b.title == title);


            if (book != null)
            {
                BookDTO dTO = new BookDTO();
                dTO.title = book.title;

                List<Publisher> publisher = _bookContext.Publishers.Where(p => p.book.Contains(book))
                                                                    .ToList();
                List<Author> authors = _bookContext.Authors.Where(a => a.Books.Contains(book))
                                                           .ToList();
                book.publisher = publisher;
                book.authors = authors;
                foreach (var pub in book.publisher)
                {
                    PublisherDTO publisherDTO = new PublisherDTO();
                    publisherDTO.Name = pub.Name;
                    dTO.publisher = publisherDTO;
                }


                foreach (var author in book.authors)
                {
                    AuthorDTO authorDTO = new AuthorDTO();
                    authorDTO.Firstname = author.Firstname;
                    authorDTO.Lastname = author.Lastname;
                    foreach (var detail in _bookContext.AuthorContact)
                    {
                        if (detail.AuthorId == author.Id)
                            authorDTO.details = detail;
                    }
                    dTO.authors.Add(authorDTO);
                }

                return dTO;
            }
            return null;
        }

        public List<BookDTO> GetBooks()
        {
            List<Book> books = _bookContext.Books.ToList();
            List<BookDTO> booksDTO = new List<BookDTO>();
            foreach (var book in books)
            {
                BookDTO dTO = new BookDTO();
                dTO.title = book.title;

                List<Publisher> publisher = _bookContext.Publishers.Where(p => p.book.Contains(book))
                                                                    .ToList();
                List<Author> authors = _bookContext.Authors.Where(a => a.Books.Contains(book))
                                                           .ToList();
                book.publisher = publisher;
                book.authors = authors;

                foreach (var pub in book.publisher)
                {
                    PublisherDTO publisherDTO = new PublisherDTO();
                    publisherDTO.Name = pub.Name;
                    dTO.publisher = publisherDTO;
                }


                foreach (var author in book.authors)
                {
                    AuthorDTO authorDTO = new AuthorDTO();
                    authorDTO.Firstname = author.Firstname;
                    authorDTO.Lastname = author.Lastname;
                    foreach(var detail in _bookContext.AuthorContact)
                    {
                        if (detail.AuthorId == author.Id)
                            authorDTO.details = detail;
                    }
                    dTO.authors.Add(authorDTO);
                }

                booksDTO.Add(dTO);
            }
            return booksDTO;
        }

        
    }
}
