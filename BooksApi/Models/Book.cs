using System.ComponentModel.DataAnnotations;

namespace BooksApi.Models
{
    public class Book
    {
        [Key]
        public long Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }

        public long AuthorId { get; set; }
        public Author Author { get; set; }
        public long GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}
