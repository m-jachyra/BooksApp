namespace BooksApi.Models
{
    public class ReviewListDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Rate { get; set; }
        public UserReviewDto User { get; set; }
    }

    public class ReviewDetailDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Rate { get; set; }
        public string Username { get; set; }
    }

    public class ReviewCreateDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int Rate { get; set; }
        public long BookId { get; set; }
        public string UserId { get; set; }
    }
}
