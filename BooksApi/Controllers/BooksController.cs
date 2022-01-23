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
                            AuthorId = b.AuthorId,
                            AuthorName = b.Author.AuthorName,
                            GenreId = b.GenreId,
                            GenreName = b.Genre.GenreName
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
                            AuthorId = b.Author.Id,
                            AuthorName = b.Author.AuthorName,
                            GenreId = b.Genre.Id,
                            GenreName = b.Genre.GenreName
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
                return BadRequest();
            }

            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            book.Title = bookDto.Title;
            book.Description = bookDto.Description;
            book.AuthorId = bookDto.AuthorId;
            book.GenreId = bookDto.GenreId;

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
                AuthorId = bookDto.AuthorId,
                GenreId = bookDto.GenreId
            };

            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetBook),
                new { id = book.Id },
                book);
        }

        [HttpDelete]
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

        [HttpGet("{id}/image")]
        [AllowAnonymous]
        public IActionResult Image(long id)
        {
            FileStream image;
            try
            {
                image = System.IO.File.OpenRead($"C:\\images\\books\\{id}.PNG");
            }
            catch
            {
                image = System.IO.File.OpenRead("C:\\images\\books\\default.PNG");
            };

            return File(image, "image/png");
        }

        private bool BookExists(long id)
        {
            return _context.Books.Any(e => e.Id == id);
        }
    }
}
