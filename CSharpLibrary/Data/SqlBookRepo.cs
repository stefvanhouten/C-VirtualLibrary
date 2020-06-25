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
            return _context.Book.ToList();
        }


        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
