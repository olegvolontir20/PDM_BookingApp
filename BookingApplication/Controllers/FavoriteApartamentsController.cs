using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookingApplication.DAL;
using BookingApplication.Entities.Models;

namespace BookingApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteApartamentsController : ControllerBase
    {
        private readonly DataContext _context;

        public FavoriteApartamentsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FavoriteApartament>>> GetFavoriteApartament(int userId)
        {
            List<Apartament> favoriteApartaments = await _context.FavoriteApartament
                   .Where(fa => fa.UserId == userId)
                   .Select(fa => fa.Apartament)
                   .ToListAsync();

            if (favoriteApartaments == null || favoriteApartaments.Count == 0)
            {
                return NotFound();
            }

            return Ok(favoriteApartaments);
        }

        [HttpPost("AddFavoriteApartament")]
        public async Task<ActionResult<FavoriteApartament>> PostFavoriteApartament(int userId, int apartamentId)
        {
            FavoriteApartament fav = new();
            fav.UserId = userId;
            fav.ApartamentId = apartamentId;
            _context.FavoriteApartament.Add(fav);
            await _context.SaveChangesAsync();

            return Ok("Succes!");
        }

        [HttpGet("CheckIfApartamentIsFavorite")]
        public async Task<IActionResult> CheckIfApartamentIsFavorite(int userId, int apartamentId)
        {
            User user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                return NotFound();
            }

            bool isFavorite = await _context.FavoriteApartament
                .AnyAsync(fa => fa.UserId == userId && fa.ApartamentId == apartamentId);

            return Ok(isFavorite);
        }

        //// GET: api/FavoriteApartaments
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<FavoriteApartament>>> GetFavoriteApartaments()
        //{
        //  if (_context.FavoriteApartament == null)
        //  {
        //      return NotFound();
        //  }
        //    return await _context.FavoriteApartament.ToListAsync();
        //}

        // GET: api/FavoriteApartaments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FavoriteApartament>> GetFavoriteApartamentById(int id)
        {
          if (_context.FavoriteApartament == null)
          {
              return NotFound();
          }
            var favoriteApartament = await _context.FavoriteApartament.FindAsync(id);

            if (favoriteApartament == null)
            {
                return NotFound();
            }

            return favoriteApartament;
        }

        // PUT: api/FavoriteApartaments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFavoriteApartament(int id, FavoriteApartament favoriteApartament)
        {
            if (id != favoriteApartament.Id)
            {
                return BadRequest();
            }

            _context.Entry(favoriteApartament).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FavoriteApartamentExists(id))
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

        // POST: api/FavoriteApartaments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FavoriteApartament>> PostFavoriteApartament(FavoriteApartament favoriteApartament)
        {
          if (_context.FavoriteApartament == null)
          {
              return Problem("Entity set 'DataContext.FavoriteApartament'  is null.");
          }
            _context.FavoriteApartament.Add(favoriteApartament);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFavoriteApartament", new { id = favoriteApartament.Id }, favoriteApartament);
        }

        // DELETE: api/FavoriteApartaments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFavoriteApartament(int id)
        {
            if (_context.FavoriteApartament == null)
            {
                return NotFound();
            }
            var favoriteApartament = await _context.FavoriteApartament.FindAsync(id);
            if (favoriteApartament == null)
            {
                return NotFound();
            }

            _context.FavoriteApartament.Remove(favoriteApartament);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("DeleteFavoriteApartament")]
        public async Task<IActionResult> RemoveFavoriteApartament(int userId, int apartamentId)
        {
            FavoriteApartament favoriteApartament = await _context.FavoriteApartament
                .FirstOrDefaultAsync(fa => fa.UserId == userId && fa.ApartamentId == apartamentId);

            if (favoriteApartament == null)
            {
                return NotFound();
            }

            _context.FavoriteApartament.Remove(favoriteApartament);
            await _context.SaveChangesAsync();

            return Ok("Succes!");
        }

        private bool FavoriteApartamentExists(int id)
        {
            return (_context.FavoriteApartament?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
