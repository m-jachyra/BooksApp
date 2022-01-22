using System;

namespace BooksApi.Models
{
    public class AuthorListDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }

    public class AuthorCreateDto
    {
        public string AuthorName { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? DeathDate { get; set; }
        public string? Biography { get; set; }
    }

    public class AuthorDetailDto
    {
        public long Id { get; set; }
        public string AuthorName { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? DeathDate { get; set; }
        public string? Biography { get; set; }
    }
}

