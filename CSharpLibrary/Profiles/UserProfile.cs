using AutoMapper;
using CSharpLibrary.Dtos.UserDto;
using CSharpLibrary.Models;
using System.Collections;
using System.Collections.Generic;

namespace CSharpLibrary.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserReadDto>();
            CreateMap<RentedBook, UserReadDto.RentedBookDto>();
        }
    }
}