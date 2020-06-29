using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CSharpLibrary.Models
{
    public class RentedBook
    {
        [Key]
        public int RentedBookId { get; set; }

        [Required]
        [ForeignKey("Book")]
        public int BookId { get; set; }

        public Book Book { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }

        public User User { get; set; }

    }
}
