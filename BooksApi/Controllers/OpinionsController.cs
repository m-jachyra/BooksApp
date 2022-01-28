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
    public class OpinionsController : ControllerBase
    {
        private AppDbContext _context;

        public OpinionsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [AllowAnonymous]
        public IQueryable<OpinionListDto> GetOpinion()
        {
            var opinions = from o in _context.Opinions
                           select new OpinionListDto()
                           {
                               Rate = o.Rate,
                               Username = o.User.UserName
                           };

            return opinions;
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetOpinion(long id)
        {
            var opinion = await _context.Opinions.Select(o =>
                        new OpinionDetailDto()
                        {
                            Id = o.Id,
                            Rate = o.Rate,
                            UserId = o.UserId,
                            ReviewId = o.ReviewId
                        }).SingleOrDefaultAsync(o => o.Id == id);

            if (opinion == null)
            {
                return NotFound();
            }
            return Ok(opinion);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateOpinion(long id, OpinionDetailDto opinionDto)
        {
            if (id != opinionDto.Id)
            {
                return BadRequest();
            }

            var opinion = await _context.Opinions.FindAsync(id);
            if (opinion == null)
            {
                return NotFound();
            }

            opinion.Rate = opinionDto.Rate;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!OpinionExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<OpinionCreateDto>> CreateOpinion(OpinionCreateDto opinionDto)
        {
            var opinion = new Opinion
            {
                Rate = opinionDto.Rate,
                ReviewId = opinionDto.ReviewId,
                UserId = opinionDto.UserId
            };

            _context.Opinions.Add(opinion);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetOpinion),
                new { id = opinion.Id },
                opinion);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteOpinion(long id)
        {
            var opinion = await _context.Opinions.FindAsync(id);

            if (opinion == null)
            {
                return NotFound();
            }

            _context.Opinions.Remove(opinion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OpinionExists(long id)
        {
            return _context.Opinions.Any(e => e.Id == id);
        }
    }
}
