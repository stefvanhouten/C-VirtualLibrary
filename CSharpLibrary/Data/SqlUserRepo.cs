using CSharpLibrary.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                .Include(u => u.Posts)
                .Include(u => u.RentedBooks)
                .ThenInclude(u => u.Book)
                .FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }
    }
}
