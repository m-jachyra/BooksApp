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
    public class ReviewsController : ControllerBase
    {
        private AppDbContext _context;

        public ReviewsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [AllowAnonymous]
        public IQueryable GetReviews()
        {
            var reviews = from r in _context.Reviews
                          select new ReviewListDto()
                          {
                              Title = r.Title,
                              Content = r.Content,
                              Rate = r.Rate,
                              Username = r.User.UserName
                          };

            return reviews;
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetReview(long id)
        {
            var review = await _context.Reviews.Select(r =>
                        new ReviewDetailDto()
                        {
                            Id = r.Id,
                            Title = r.Title,
                            Content = r.Content,
                            Rate = r.Rate,
                            Username = r.User.UserName
                        }).SingleOrDefaultAsync(r => r.Id == id);

            if (review == null)
            {
                return NotFound();
            }

            return Ok(review);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateReview(long id, ReviewDetailDto reviewDto)
        {
            if (id != reviewDto.Id)
            {
                return BadRequest();
            }

            var review = await _context.Reviews.FindAsync(id);
            if (review == null)
            {
                return NotFound();
            }

            review.Rate = reviewDto.Rate;
            review.Title = reviewDto.Title;
            review.Content = reviewDto.Content;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!ReviewExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<ReviewCreateDto>> CreateReview(ReviewCreateDto reviewDto)
        {
            var review = new Review
            {
                Rate = reviewDto.Rate,
                Title = reviewDto.Title,
                Content = reviewDto.Content
            };

            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetReview),
                new { id = review.Id },
                review);
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeleteReview(long id)
        {
            var review = await _context.Reviews.FindAsync(id);

            if (review == null)
            {
                return NotFound();
            }

            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("{id}/opinions")]
        [AllowAnonymous]
        public IActionResult GetOpinions(long id)
        {
            var positives = (from r in _context.Reviews
                             join o in _context.Opinions
                             on r.Id equals o.ReviewId
                             where o.Rate == true
                             where r.Id == id
                             select o).Count();

            var negatives = (from r in _context.Reviews
                             join o in _context.Opinions
                             on r.Id equals o.ReviewId
                             where o.Rate == false
                             where r.Id == id
                             select o).Count();

            var opinions = new
            {
                Positives = positives,
                Negatives = negatives
            };

            return Ok(opinions);
        }

        private bool ReviewExists(long id)
        {
            return _context.Reviews.Any(e => e.Id == id);
        }
    }
}
