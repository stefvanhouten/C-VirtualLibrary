using CSharpLibrary.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;

namespace CSharpLibrary.Controllers
{

    [Route("api/book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepo _context;

        public BookController(IBookRepo context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public ActionResult<int> GetBookById(int id)
        {
            var result = _context.GetBookById(id);
            return Ok(result);
        }
    }
}
