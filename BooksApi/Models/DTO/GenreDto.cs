namespace BooksApi.Models
{
    public class GenreDetailDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }

    public class GenreCreateDto
    {
        public string Name { get; set; }
    }
}
