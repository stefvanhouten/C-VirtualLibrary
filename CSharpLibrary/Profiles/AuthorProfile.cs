using CSharpLibrary.Dtos.AuthorDto;
using CSharpLibrary.Models;
using AutoMapper;


namespace CSharpLibrary.Profiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<Author, AuthorReadDto>();
        }
    }
}
