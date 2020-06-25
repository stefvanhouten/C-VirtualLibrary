using CSharpLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CSharpLibrary.Data
{
    public class SqlUserRepo : IUserRepo
    {
        private readonly UserContext _context;

        public SqlUserRepo(UserContext context)
        {
            _context = context;
        }

        public User GetUserById(int id)
        {
            return _context.Users
                .Include(u => u.RentedBooks)
                .ThenInclude(u => u.Book)
                .FirstOrDefault(p => p.UserId == id);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }
    }
}
