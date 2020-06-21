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

        public virtual ICollection<PostDto> Posts { get; set; }
        public ICollection<RentedBookDto> RentedBooks { get; set; }

        public class PostDto
        {
            public string Title;
        }

        public class RentedBookDto
        {
            public Book Book;
        }
    }


}
