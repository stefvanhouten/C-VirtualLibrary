using CSharpLibrary.Models;
using System.Collections;
using System.Collections.Generic;

namespace CSharpLibrary.Data
{
    public interface IBookRepo
    {
        Book GetBookById(int id);
        IEnumerable<Book> GetBooks();
        void CreateBook(Book book);
        bool SaveChanges();
    }
}
