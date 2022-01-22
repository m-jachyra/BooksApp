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
    public class AuthorsController : ControllerBase
    {
        private AppDbContext _context;

        public AuthorsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize]
        public IQueryable<AuthorListDto> GetAuthors()
        {
            var books = from a in _context.Authors
                        select new AuthorListDto()
                        {
                            Id = a.Id,
                            Name = a.AuthorName
                        };

            return books;
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAuthor(long id)
        {
            var author = await _context.Authors.Select(a =>
                        new AuthorDetailDto()
                        {
                            Id = a.Id,
                            AuthorName = a.AuthorName,
                            Biography = a.Biography,
                            BirthDate = a.BirthDate,
                            DeathDate = a.DeathDate
                        }).SingleOrDefaultAsync(a => a.Id == id);

            if (author == null)
            {
                return NotFound();
            }
            return Ok(author);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateAuthor(long id, AuthorDetailDto authorDto)
        {
            if (id != authorDto.Id)
            {
                return BadRequest();
            }

            var author = await _context.Authors.FindAsync(id);
            if (author == null)
            {
                return NotFound();
            }

            author.AuthorName = authorDto.AuthorName;
            author.BirthDate = authorDto.BirthDate;
            author.DeathDate = authorDto.DeathDate;
            author.Biography = authorDto.Biography;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!AuthorExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<AuthorDetailDto>> CreateAuthor(AuthorCreateDto authorDto)
        {
            var author = new Author
            {
                AuthorName = authorDto.AuthorName,
                BirthDate = authorDto.BirthDate,
                DeathDate = authorDto.DeathDate,
                Biography = authorDto.Biography
            };

            _context.Authors.Add(author);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetAuthor),
                new { id = author.Id },
                author);
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeleteAuthor(long id)
        {
            var author = await _context.Authors.FindAsync(id);

            if (author == null)
            {
                return NotFound();
            }

            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("{id}/image")]
        public IActionResult Image(long id)
        {
            FileStream image;
            try
            {
                image = System.IO.File.OpenRead($"C:\\images\\authors\\{id}.PNG");
            }
            catch
            {
                image = System.IO.File.OpenRead("C:\\images\\authors\\default.PNG");
            };

            return File(image, "image/png");
        }

        private bool AuthorExists(long id)
        {
            return _context.Authors.Any(e => e.Id == id);
        }
    }
}
