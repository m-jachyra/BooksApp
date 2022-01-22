namespace BooksApi.Models
{
    public class OpinionListDto
    {
        public bool Rate { get; set; }
        public string Username { get; set; }
    }

    public class OpinionDetailDto
    {
        public long Id { get; set; }
        public bool Rate { get; set; }

        public string UserId { get; set; }
        public long ReviewId { get; set; }
    }

    public class OpinionCreateDto
    {
        public bool Rate { get; set; }

        public string UserId { get; set; }
        public long ReviewId { get; set; }
    }
}
