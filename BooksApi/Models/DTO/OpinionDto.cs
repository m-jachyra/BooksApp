namespace BooksApi.Models
{
    public class OpinionDto
    {
        public long Id { get; set; }
        public bool Rate { get; set; }

        public string UserId { get; set; }
        public long ReviewId { get; set; }
    }
}
