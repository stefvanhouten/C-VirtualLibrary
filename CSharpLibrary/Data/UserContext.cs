using CSharpLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace CSharpLibrary.Data
{
    public class UserContext : DbContext
    {
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
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Book { get; set; }
    }
}
