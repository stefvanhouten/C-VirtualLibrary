using CSharpLibrary.Models;

namespace CSharpLibrary.Data
{
    public interface IBookRepo
    {
        Book GetBookById(int id);
        void CreateBook(Book book);
        bool SaveChanges();
    }
}
