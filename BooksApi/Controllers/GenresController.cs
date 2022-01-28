using BooksApi.Entity;
using BooksApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BooksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private AppDbContext _context;

        public GenresController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [AllowAnonymous]
        public IQueryable<GenreDetailDto> GetGenres()
        {
            var books = from g in _context.Genres
                        select new GenreDetailDto()
                        {
                            Id = g.Id,
                            Name = g.GenreName
                        };

            return books;
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetGenre(long id)
        {
            var genre = await _context.Genres.Select(g =>
            new GenreDetailDto()
            {
                Id = g.Id,
                Name = g.GenreName
            }).SingleOrDefaultAsync(g => g.Id == id);

            if (genre == null)
            {
                return NotFound();
            }

            return Ok(genre);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateGenre(long id, GenreDetailDto genreDto)
        {
            if (id != genreDto.Id)
            {
                return BadRequest();
            }

            var genre = await _context.Genres.FindAsync(id);
            if (genre == null)
            {
                return NotFound();
            }

            genre.GenreName = genreDto.Name;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!GenreExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<GenreDetailDto>> CreateGenre(GenreCreateDto genreDto)
        {
            var genre = new Genre
            {
                GenreName = genreDto.Name,
            };

            _context.Genres.Add(genre);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetGenre),
                new { id = genre.Id },
                genre);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteGenre(long id)
        {
            var genre = await _context.Genres.FindAsync(id);

            if (genre == null)
            {
                return NotFound();
            }

            _context.Genres.Remove(genre);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GenreExists(long id)
        {
            return _context.Genres.Any(e => e.Id == id);
        }
    }
}