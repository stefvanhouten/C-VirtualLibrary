using CSharpLibrary.Data;
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

        public UserController(IUserRepo repository)
        {
            _repository = repository;
        }

        /*
         * USERS routes
         */
        [HttpGet("users/")]
        public ActionResult<IEnumerable<User>> GetAllUsers()
        {
            var users = _repository.GetAllUsers();
            return Ok(users);
        }

        /* 
         * USER ROUTES
         */
        [HttpGet("user/{id}")]
        public ActionResult<User> GetUserById(int id)
        {
            var user = _repository.GetUserById(id);
            if(user != null)
            {
                return Ok(user);
            }
            return NotFound();
        }
    }
}
