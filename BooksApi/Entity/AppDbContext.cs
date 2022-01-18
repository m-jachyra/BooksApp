using BooksApi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BooksApi.Entity
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public DbSet<Author> Authors { get; set;}
        public DbSet<Book> Books { get; set;}
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Opinion> Opinions { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.SeedUsersData();
            modelBuilder.SeedAuthorsData();
            modelBuilder.SeedGenresData();
            modelBuilder.SeedBooksData();
            modelBuilder.SeedReviewsData();
            modelBuilder.SeedOpinionsData();
        }
    }
}
