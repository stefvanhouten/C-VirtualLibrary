using System.ComponentModel.DataAnnotations;

namespace CSharpLibrary.Dtos.BookDto
{
    public class BookCreateDto
    {
        [Required]
        [MaxLength(255)]
        public string Title { get; set; }
    }
}
