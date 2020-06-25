using AutoMapper;
using CSharpLibrary.Data;
using CSharpLibrary.Dtos.UserDto;
using CSharpLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpLibrary.Controllers
{
    [Route("api/")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo _repository;
        private readonly IMapper _mapper;


        public UserController(IUserRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /*
         * USERS routes
         */
        [HttpGet("users/")]
        public ActionResult<IEnumerable<UserListDto>> GetAllUsers()
        {
            var users = _repository.GetAllUsers();
            if(!users.Any())
            {
                return NotFound();
            }
            return Ok(_mapper.Map<IEnumerable<UserListDto>>(users));
        }

        /* 
         * USER ROUTES
         */
        [HttpGet("user/{id}")]
        public ActionResult<UserReadDto> GetUserById(int id)
        {
            var user = _repository.GetUserById(id);
            if(user == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<UserReadDto>(user));
        }
    }
}
