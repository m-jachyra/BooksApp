using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BooksApi.Models
{
    public class Review
    {
        [Key]
        public long Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Rate { get; set; }

        public long BookId { get; set; }
        public Book Book { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public List<Opinion> ReviewOpinions { get; set; }
    }
}
