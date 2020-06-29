using CSharpLibrary.Dtos.AuthorDto;
using CSharpLibrary.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSharpLibrary.Dtos.BookDto
{
    public class BookCreateDto
    {
        [Required]
        [MaxLength(255)]
        public string Title { get; set; }

        [Required]
        [Range(1, double.PositiveInfinity)]
        public int ISBN { get; set; }

        [Required]
        [ForeignKey("Author")]
        [Range(1, double.PositiveInfinity)]
        public int AuthorId { get; set; }
    }
}
