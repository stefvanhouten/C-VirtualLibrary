using CSharpLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace CSharpLibrary.Dtos.UserDto
{
    public class UserReadDto
    {
        public string Name;

        public virtual ICollection<Post> Posts { get; set; }
        public ICollection<RentedBook> RentedBooks { get; set; }
    }

}
