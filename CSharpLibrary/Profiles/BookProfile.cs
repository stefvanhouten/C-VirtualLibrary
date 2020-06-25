using AutoMapper;
using CSharpLibrary.Dtos.AuthorDto;
using CSharpLibrary.Dtos.BookDto;
using CSharpLibrary.Models;

namespace CSharpLibrary.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookReadDto>();
            //CreateMap<BookReadDto, AuthorReadDto>();            //CreateMap<BookReadDto, AuthorReadDto>();
            CreateMap<BookCreateDto, Book>();
        }
    }
}
