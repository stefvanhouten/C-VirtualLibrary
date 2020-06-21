using AutoMapper;
using CSharpLibrary.Data;
using CSharpLibrary.Dtos.BookDto;
using CSharpLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace CSharpLibrary.Controllers
{

    [Route("api/book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepo _repository;
        private readonly IMapper _mapper;

        public BookController(IBookRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("{id}", Name ="GetBookById")]
        public ActionResult<BookReadDto> GetBookById(int id)
        {
            var bookModel = _repository.GetBookById(id);
            if(bookModel != null)
            {
                return Ok(_mapper.Map<BookReadDto>(bookModel));
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult <BookReadDto> CreateBook(BookCreateDto bookCreateDto)
        {
            var bookModel = _mapper.Map<Book>(bookCreateDto);
            _repository.CreateBook(bookModel);
            _repository.SaveChanges();
            var bookReadDto = _mapper.Map<BookReadDto>(bookModel);
            return CreatedAtRoute(nameof(GetBookById), new { bookModel.Id }, bookReadDto);
        }
    }
}
