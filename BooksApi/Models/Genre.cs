using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BooksApi.Models
{
    public class Genre
    {
        [Key]
        public long Id { get; set; }
        public string GenreName { get; set; }

        public List<Book> Books { get; set; }
    }
}
