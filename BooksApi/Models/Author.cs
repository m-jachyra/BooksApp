using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BooksApi.Models
{
    public class Author
    {
        [Key]
        public long Id { get; set; }
        public string AuthorName { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? DeathDate { get; set; }
        public string? Biography { get; set; }

        public List<Book> Books { get; set; }
    }
}
