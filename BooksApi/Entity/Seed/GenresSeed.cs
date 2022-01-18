using BooksApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksApi.Entity
{
    public static class GenresSeed
    {
        public static void SeedGenresData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasData(
                new Genre
                {
                    Id = 1,
                    GenreName = "Fantasy"
                },
                new Genre
                {
                    Id = 2,
                    GenreName = "Horror"
                },
                new Genre
                {
                    Id = 3,
                    GenreName = "Criminal"
                },
                new Genre
                {
                    Id = 4,
                    GenreName = "Romance"
                },
                new Genre
                {
                    Id = 5,
                    GenreName = "Drama"
                },
                new Genre
                {
                    Id = 6,
                    GenreName = "Historic"
                },
                new Genre
                {
                    Id = 7,
                    GenreName = "Slice of life"
                }
            );
        }
    }
}
