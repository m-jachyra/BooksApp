namespace BooksApi.Models
{
    public class GenreDetailDto
    {
        public long Id { get; set; }
        public string GenreName { get; set; }
    }

    public class GenreCreateDto
    {
        public string GenreName { get; set; }
    }
}
