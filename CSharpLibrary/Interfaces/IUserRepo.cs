
using CSharpLibrary.Models;
using System.Collections;
using System.Collections.Generic;

namespace CSharpLibrary.Data
{
    public interface IUserRepo
    {
        User GetUserById(int id);
        IEnumerable<User> GetAllUsers();
    }
}
