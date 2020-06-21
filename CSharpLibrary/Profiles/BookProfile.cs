using AutoMapper;
using CSharpLibrary.Dtos.BookDto;
using CSharpLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharpLibrary.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookReadDto>();
        }
    }
}
