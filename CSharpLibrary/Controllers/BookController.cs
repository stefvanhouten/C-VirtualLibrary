using AutoMapper;
using CSharpLibrary.Data;
using CSharpLibrary.Dtos.BookDto;
using CSharpLibrary.Dtos.RentedBookDto;
using CSharpLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using System.Net;

namespace CSharpLibrary.Controllers
{

    [Route("api/")]
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

        [HttpGet("book/{id}", Name = "GetBookById")]
        public ActionResult<BookReadDto> GetBookById(int id)
        {
            var bookModel = _repository.GetBookById(id);
            if(bookModel == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<BookReadDto>(bookModel));
        }

        [HttpGet("books")]
        public ActionResult<IEnumerable<BookReadDto>> GetBooks()
        {
            var bookItems = _repository.GetBooks();
            if(bookItems == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<IEnumerable<BookReadDto>>(bookItems));
        }

        [HttpPost("book")]
        public ActionResult<BookReadDto> CreateBook(BookCreateDto bookCreateDto)
        {
            if (_repository.IsbnExists(bookCreateDto.ISBN))
            {
                return Conflict(new { 
                    message = $"An existing record with the ISBN '{bookCreateDto.ISBN}' was already found.",
                    type = "https://tools.ietf.org/html/rfc7231#section-6.5.8",
                    status = 409
                });
            }
            Book bookModel = _mapper.Map<Book>(bookCreateDto);
            _repository.CreateBook(bookModel);
            _repository.SaveChanges();
            BookReadDto bookReadDto = _mapper.Map<BookReadDto>(_repository.GetBookById(bookModel.BookId));
            return CreatedAtRoute(nameof(GetBookById), new { id = bookModel.BookId }, bookReadDto);
        }

        [HttpPost("book/rent")]
        public ActionResult<CreateRentedBook> RentBook(CreateRentedBook rentedBook)
        {
            RentedBook rented = _mapper.Map<RentedBook>(rentedBook);
            try
            {
                var test = _repository.RentBook(rented);
                _repository.SaveChanges();
                CreateRentedBook rentBookDto = _mapper.Map<CreateRentedBook>(test);
                return Ok(rentBookDto);
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Data["Error"]);
            }
        }
    }
}
