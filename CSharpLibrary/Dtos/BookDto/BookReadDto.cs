using CSharpLibrary.Dtos.AuthorDto;

namespace CSharpLibrary.Dtos.BookDto
{
    public class BookReadDto
    {
        public string Title { get; set; }
        public AuthorReadDto Author { get; set; }
    }
}
