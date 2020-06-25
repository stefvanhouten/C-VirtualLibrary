using System.Collections.Generic;
using CSharpLibrary.Dtos.BookDto;

namespace CSharpLibrary.Dtos.UserDto
{
    public class UserReadDto
    {
        public string Name;

        public ICollection<RentedBookDto> RentedBooks { get; set; }

        public class RentedBookDto
        {
            public BookReadDto Book;
        }
    }

    public class UserListDto
    {
        public int UserId;
        public string Name;
    }


}
