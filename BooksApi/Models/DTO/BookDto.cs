namespace BooksApi.Models
{
    public class BookListDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public AuthorListDto Author { get; set; }
        public GenreDetailDto Genre { get; set; }
    }

    public class BookCreateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public AuthorListDto Author { get; set; }
        public GenreDetailDto Genre { get; set; }
    }

    public class BookDetailDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public AuthorListDto Author { get; set; }
        public GenreDetailDto Genre { get; set; }
    }
}
