namespace BooksApi.Models
{
    public class BookListDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public long AuthorId { get; set; }
        public string AuthorName { get; set; }
        public long GenreId { get; set; }
        public string GenreName { get; set; }
    }

    public class BookCreateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public long AuthorId { get; set; }
        public long GenreId { get; set; }
    }

    public class BookDetailDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public long AuthorId { get; set; }
        public string AuthorName { get; set; }
        public long GenreId { get; set; }
        public string GenreName { get; set; }
    }
}
