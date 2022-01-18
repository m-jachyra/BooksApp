using System.ComponentModel.DataAnnotations;

namespace BooksApi.Models
{
    public class Opinion
    {
        [Key]
        public long Id { get; set; }
        public bool Rate { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
        public long ReviewId { get; set; }
        public Review Review { get; set; }
    }
}
