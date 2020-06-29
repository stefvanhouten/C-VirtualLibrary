using AutoMapper;
using CSharpLibrary.Dtos.AuthorDto;
using CSharpLibrary.Dtos.RentedBookDto;
using CSharpLibrary.Dtos.BookDto;
using CSharpLibrary.Models;

namespace CSharpLibrary.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookReadDto>();
            CreateMap<BookCreateDto, Book>();

            CreateMap<CreateRentedBook, RentedBook>();
            CreateMap<RentedBook, CreateRentedBook>();

        }
    }
}
