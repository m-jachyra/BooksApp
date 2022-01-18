using BooksApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace BooksApi.Entity
{
    public static class AuthorsSeed
    {
        public static void SeedAuthorsData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(
                new Author
                {
                    Id = 3,
                    AuthorName = "J. R. R. Tolkien",
                    BirthDate = DateTime.Parse("1892-01-03"),
                    DeathDate = DateTime.Parse("1973-09-02"),
                    Biography = "Lorem Ipsum Dolor Sit Amet"
                },
                new Author
                {
                    Id = 4,
                    AuthorName = "George R.R. Martin",
                    BirthDate = DateTime.Parse("1948-09-20"),
                    Biography = "Lorem Ipsum Dolor Sit Amet"
                },
                new Author
                {
                    Id = 5,
                    AuthorName = "Stephanie Meyer",
                    BirthDate = DateTime.Parse("1973-12-24"),
                    Biography = "Lorem Ipsum Dolor Sit Amet"
                },
                new Author
                {
                    Id = 6,
                    AuthorName = "J.K. Rowling",
                    BirthDate = DateTime.Parse("1965-07-31"),
                    Biography = "Lorem Ipsum Dolor Sit Amet"
                },
                new Author
                {
                    Id = 7,
                    AuthorName = "Remigiusz Mróz",
                    BirthDate = DateTime.Parse("1987-01-15"),
                    Biography = "Lorem Ipsum Dolor Sit Amet"
                },
                new Author
                {
                    Id = 8,
                    AuthorName = "Henryk Sienkiewicz",
                    BirthDate = DateTime.Parse("1846-05-05"),
                    DeathDate = DateTime.Parse("1916-11-15"),
                    Biography = "Lorem Ipsum Dolor Sit Amet"
                },
                new Author
                {
                    Id = 9,
                    AuthorName = "Bolesław Prus",
                    BirthDate = DateTime.Parse("1847-08-20"),
                    DeathDate = DateTime.Parse("1912-05-19"),
                    Biography = "Lorem Ipsum Dolor Sit Amet"
                }
                ,
                new Author
                {
                    Id = 10,
                    AuthorName = "Władysław Reymont",
                    BirthDate = DateTime.Parse("1867-05-07"),
                    DeathDate = DateTime.Parse("1925-12-05"),
                    Biography = "Lorem Ipsum Dolor Sit Amet"
                }
                ,
                new Author
                {
                    Id = 11,
                    AuthorName = "Andrzej Sapkowski",
                    BirthDate = DateTime.Parse("1948-05-21"),
                    Biography = "Lorem Ipsum Dolor Sit Amet"
                }
                ,
                new Author
                {
                    Id = 12,
                    AuthorName = "Stephan King",
                    BirthDate = DateTime.Parse("1947-09-21"),
                    Biography = "Lorem Ipsum Dolor Sit Amet"
                }
                ,
                new Author
                {
                    Id = 13,
                    AuthorName = "E.L. James",
                    BirthDate = DateTime.Parse("1963-03-07"),
                    Biography = "Lorem Ipsum Dolor Sit Amet"
                }
                ,
                new Author
                {
                    Id = 14,
                    AuthorName = "Alicja Sinicka",
                    BirthDate = DateTime.Parse("1987-04-15"),
                    Biography = "Lorem Ipsum Dolor Sit Amet"
                }
                ,
                new Author
                {
                    Id = 15,
                    AuthorName = "William Shakespeare",
                    BirthDate = DateTime.Parse("1564-04-23"),
                    DeathDate = DateTime.Parse("1616-05-03"),
                    Biography = "Lorem Ipsum Dolor Sit Amet"
                }
                ,
                new Author
                {
                    Id = 16,
                    AuthorName = "Juliusz Słowacki",
                    BirthDate = DateTime.Parse("1809-09-04"),
                    DeathDate = DateTime.Parse("1949-04-03"),
                    Biography = "Lorem Ipsum Dolor Sit Amet"
                }
                ,
                new Author
                {
                    Id = 17,
                    AuthorName = "Olga Tokarczuk",
                    BirthDate = DateTime.Parse("1962-01-29"),
                    Biography = "Lorem Ipsum Dolor Sit Amet"
                }
            );
        }
    }
}
