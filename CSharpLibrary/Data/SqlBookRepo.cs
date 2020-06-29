using CSharpLibrary.Dtos.RentedBookDto;
using CSharpLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpLibrary.Data
{
    public class SqlBookRepo : IBookRepo
    {
        private readonly UserContext _context;

        public SqlBookRepo(UserContext context)
        {
            _context = context;
        }

        public bool IsbnExists(int isbn)
        {
            return _context.Book.Any(b => b.ISBN == isbn);
        }

        public void CreateBook(Book book)
        {
            if(book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }

            _context.Book.Add(book);
            SaveChanges();
        }

        public Book GetBookById(int id)
        {
            return _context.Book
                .Include(b => b.Author)
                .FirstOrDefault(b => b.BookId == id);
        }

        public IEnumerable<Book> GetBooks()
        {
            return _context.Book
                .Include(b => b.Author)
                .ToList();
        }


        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public RentedBook RentBook(RentedBook rentBook)
        {
            if (_context.Book.FirstOrDefault(b => b.BookId == rentBook.BookId) == null)
            {
                KeyNotFoundException e = new KeyNotFoundException("");
                e.Data["Error"] = new
                {
                    Errors = new
                    {
                        BookId = $"Book with id {rentBook.BookId} could not be found"
                    },
                    Type = "https://tools.ietf.org/html/rfc7231#section-6.5.4",
                    Status = 404
                };
                throw e;
            }

            if (_context.Users.FirstOrDefault(u => u.UserId == rentBook.UserId) == null)
            {
                KeyNotFoundException e = new KeyNotFoundException("");
                e.Data["Error"] = new
                {
                    Errors = new
                    {
                        BookId = $"User with id {rentBook.UserId} could not be found"
                    },
                    Type = "https://tools.ietf.org/html/rfc7231#section-6.5.4",
                    Status = 404
                };
                throw e;
            }

            _context.RentedBook.Add(rentBook);
            SaveChanges();
            return rentBook;
        }
    }
}
