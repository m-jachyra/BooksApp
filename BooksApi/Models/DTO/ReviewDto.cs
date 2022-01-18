namespace BooksApi.Models
{
    public class ReviewDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Rate { get; set; }
        public string Username { get; set; }
    }
}
