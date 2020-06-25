using CSharpLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace CSharpLibrary.Data
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<Book> Book { get; set; }

        public UserContext(DbContextOptions<UserContext> opt) : base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>();

            modelBuilder.Entity<RentedBook>()
                .HasOne(rb => rb.User)
                .WithMany(u => u.RentedBooks);

            modelBuilder.Entity<RentedBook>()
                .HasOne(b => b.Book);

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Author);

            modelBuilder.Entity<User>().HasData(new User { UserId = 1, Name = "Stef" });
            modelBuilder.Entity<Author>().HasData(new Author { AuthorId = 1, Name = "My Author" });
            modelBuilder.Entity<Book>().HasData(new Book { BookId = 1, AuthorId = 1, Title = "C# For Dummies" });
            //modelBuilder.Entity<Book>().HasData(new Book { BookId = 1, Title = "C# For Dummies", Author = new Author { AuthorId = 1 } });
            //modelBuilder.Entity<RentedBook>().HasData(new RentedBook { RentedBookId = 1, Book = new Book { BookId = 1 }, User =  new User { UserId = 1 } });


        }

    }
}
