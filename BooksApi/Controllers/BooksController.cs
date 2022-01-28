using BooksApi.Entity;
using BooksApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BooksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private AppDbContext _context;

        public BooksController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [AllowAnonymous]
        public IQueryable<BookListDto> GetBooks()
        {
            var books = from b in _context.Books
                        select new BookListDto()
                        {
                            Id = b.Id,
                            Title = b.Title,
                            Author = new AuthorListDto
                            {
                                Id = b.Author.Id,
                                Name = b.Author.AuthorName
                            },
                            Genre = new GenreDetailDto
                            {
                                Id = b.Genre.Id,
                                Name = b.Genre.GenreName
                            }
                        };

            return books;
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetBook(long id)
        {
            var book = await _context.Books.Select(b =>
                        new BookDetailDto()
                        {
                            Id = b.Id,
                            Title = b.Title,
                            Description = b.Description,
                            Author = new AuthorListDto
                            {
                                Id = b.Author.Id,
                                Name = b.Author.AuthorName
                            },
                            Genre = new GenreDetailDto
                            {
                                Id = b.Genre.Id,
                                Name = b.Genre.GenreName
                            }
                        }).SingleOrDefaultAsync(b => b.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateBook(long id, BookDetailDto bookDto)
        {
            if (id != bookDto.Id)
            {
                return BadRequest($"Bad Id {id} != {bookDto.Id}");
            }

            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound("No Book with that Id");
            }

            book.Title = bookDto.Title;
            book.Description = bookDto.Description;
            book.AuthorId = bookDto.Author.Id;
            book.GenreId = bookDto.Genre.Id;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!BookExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<BookDetailDto>> CreateBook(BookCreateDto bookDto)
        {
            var book = new Book
            {
                Title = bookDto.Title,
                Description = bookDto.Description,
                AuthorId = bookDto.Author.Id,
                GenreId = bookDto.Genre.Id
            };

            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetBook),
                new { id = book.Id },
                book);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteBook(long id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("{id}/reviews")]
        [AllowAnonymous]
        public IQueryable<ReviewListDto> GetReviews(long id)
        {
            var reviews = from r in _context.Reviews
                          where r.BookId == id
                          select new ReviewListDto()
                          {
                              Id = r.Id,
                              Title = r.Title,
                              Content = r.Content,
                              Rate = r.Rate,
                              User = new UserReviewDto
                              {
                                  Username = r.User.UserName
                              }
                          };

            return reviews;
        }

        private bool BookExists(long id)
        {
            return _context.Books.Any(e => e.Id == id);
        }
    }
}
