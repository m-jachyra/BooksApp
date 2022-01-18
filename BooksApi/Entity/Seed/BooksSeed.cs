using BooksApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksApi.Entity
{
    public static class BooksSeed
    {
        public static void SeedBooksData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Title = "Lord of the rings",
                    Description = "Best book that was ever written.",
                    AuthorId = 3,
                    GenreId = 1
                },
                new Book
                {
                    Id = 4,
                    Title = "Game of Thrones",
                    Description = "Lorem Ipsum Dolor Sit Amet",
                    AuthorId = 4,
                    GenreId = 1
                },
                new Book
                {
                    Id = 5,
                    Title = "Hobbit",
                    Description = "Lorem Ipsum Dolor Sit Amet",
                    AuthorId = 3,
                    GenreId = 1
                },
                new Book
                {
                    Id = 6,
                    Title = "Twilight",
                    Description = "Lorem Ipsum Dolor Sit Amet",
                    AuthorId = 5,
                    GenreId = 1
                },
                new Book
                {
                    Id = 7,
                    Title = "Harry Potter",
                    Description = "Lorem Ipsum Dolor Sit Amet",
                    AuthorId = 6,
                    GenreId = 1
                },
                new Book
                {
                    Id = 8,
                    Title = "Balladyna",
                    Description = "Lorem Ipsum Dolor Sit Amet",
                    AuthorId = 16,
                    GenreId = 5
                },
                new Book
                {
                    Id = 9,
                    Title = "Król Lear",
                    Description = "Lorem Ipsum Dolor Sit Amet",
                    AuthorId = 15,
                    GenreId = 5
                },
                new Book
                {
                    Id = 10,
                    Title = "Oczy wilka",
                    Description = "Lorem Ipsum Dolor Sit Amet",
                    AuthorId = 14,
                    GenreId = 4
                },
                new Book
                {
                    Id = 11,
                    Title = "Fifty Shades of Grey",
                    Description = "Lorem Ipsum Dolor Sit Amet",
                    AuthorId = 13,
                    GenreId = 4
                },
                new Book
                {
                    Id = 12,
                    Title = "Smętarz dla zwierzaków",
                    Description = "Lorem Ipsum Dolor Sit Amet",
                    AuthorId = 12,
                    GenreId = 2
                },
                new Book
                {
                    Id = 13,
                    Title = "It",
                    Description = "Lorem Ipsum Dolor Sit Amet",
                    AuthorId = 12,
                    GenreId = 2
                },
                new Book
                {
                    Id = 14,
                    Title = "Halny",
                    Description = "Lorem Ipsum Dolor Sit Amet",
                    AuthorId = 7,
                    GenreId = 3
                },
                new Book
                {
                    Id = 15,
                    Title = "Chłopi",
                    Description = "Lorem Ipsum Dolor Sit Amet",
                    AuthorId = 10,
                    GenreId = 6
                },
                new Book
                {
                    Id = 16,
                    Title = "Lalka",
                    Description = "Lorem Ipsum Dolor Sit Amet",
                    AuthorId = 9,
                    GenreId = 5
                },
                new Book
                {
                    Id = 17,
                    Title = "Potop",
                    Description = "Lorem Ipsum Dolor Sit Amet",
                    AuthorId = 8,
                    GenreId = 6
                },
                new Book
                {
                    Id = 19,
                    Title = "Bieguni",
                    Description = "Lorem Ipsum Dolor Sit Amet",
                    AuthorId = 17,
                    GenreId = 7
                },
                new Book
                {
                    Id = 24,
                    Title = "Wiedźmin",
                    Description = "Lorem Ipsum Dolor Sit Amet",
                    AuthorId = 11,
                    GenreId = 1
                }
            );
        }
    }
}
