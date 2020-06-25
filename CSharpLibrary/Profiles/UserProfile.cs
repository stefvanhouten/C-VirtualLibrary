using AutoMapper;
using CSharpLibrary.Dtos.UserDto;
using CSharpLibrary.Models;

namespace CSharpLibrary.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserReadDto>();
            CreateMap<User, UserListDto>();
            CreateMap<RentedBook, UserReadDto.RentedBookDto>();
        }
    }
}