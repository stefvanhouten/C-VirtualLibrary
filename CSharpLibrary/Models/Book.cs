using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSharpLibrary.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Title { get; set; }

        [ForeignKey("Author")]
        public int AuthorId { get; set; }

        [Required]
        public Author Author { get; set; }
    }
}
