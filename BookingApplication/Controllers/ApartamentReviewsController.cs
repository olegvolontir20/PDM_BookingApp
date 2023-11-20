using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookingApplication.DAL;
using BookingApplication.Entities.Models;
using Microsoft.AspNetCore.Authorization;

namespace BookingApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartamentReviewsController : ControllerBase
    {
        private readonly DataContext _context;

        public ApartamentReviewsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/ApartamentReviews
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApartamentReview>>> GetApartamentReviews()
        {
          if (_context.ApartamentReviews == null)
          {
              return NotFound();
          }
            return await _context.ApartamentReviews.Include(x => x.User).Include(x => x.Apartament).ToListAsync();
        }

        // GET: api/ApartamentReviews/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ApartamentReview>> GetApartamentReview(int id)
        {
          if (_context.ApartamentReviews == null)
          {
              return NotFound();
          }
            var apartamentReview = await _context.ApartamentReviews.Include(x => x.User).Include(x => x.Apartament).FirstOrDefaultAsync(i => i.Id == id);

            if (apartamentReview == null)
            {
                return NotFound();
            }

            return apartamentReview;
        }

        // PUT: api/ApartamentReviews/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutApartamentReview(int id, ApartamentReview apartamentReview)
        {
            if (id != apartamentReview.Id)
            {
                return BadRequest();
            }

            _context.Entry(apartamentReview).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApartamentReviewExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ApartamentReviews
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ApartamentReview>> PostApartamentReview(ApartamentReview apartamentReview)
        {
          if (_context.ApartamentReviews == null)
          {
              return Problem("Entity set 'DataContext.ApartamentReviews'  is null.");
          }
            _context.ApartamentReviews.Add(apartamentReview);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetApartamentReview", new { id = apartamentReview.Id }, apartamentReview);
        }

        // DELETE: api/ApartamentReviews/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApartamentReview(int id)
        {
            if (_context.ApartamentReviews == null)
            {
                return NotFound();
            }
            var apartamentReview = await _context.ApartamentReviews.FindAsync(id);
            if (apartamentReview == null)
            {
                return NotFound();
            }

            _context.ApartamentReviews.Remove(apartamentReview);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ApartamentReviewExists(int id)
        {
            return (_context.ApartamentReviews?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
