using System.ComponentModel.DataAnnotations;


namespace CSharpLibrary.Dtos.RentedBookDto
{
    public class CreateRentedBook
    {   
        [Required]
        [Range(1, double.PositiveInfinity)]
        public int UserId { get; set; }

        [Required]
        [Range(1, double.PositiveInfinity)]
        public int BookId { get; set; }
    }
}
