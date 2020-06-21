using CSharpLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharpLibrary.Data
{
    public class SqlBookRepo : IBookRepo
    {
        private readonly BookContext _context;

        public SqlBookRepo(BookContext context)
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
            var book = _context.Book.FirstOrDefault(b => b.Id == id);
            return book;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
