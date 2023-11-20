using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookingApplication.DAL;
using BookingApplication.Entities.Models;
using System.Linq;


namespace BookingApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteHotelsController : ControllerBase
    {
        private readonly DataContext _context;

        public FavoriteHotelsController(DataContext context)
        {
            _context = context;
        }

        //[HttpGet("favorite")]
        //public async Task<ActionResult<FavoriteHotel>> GetFavoriteHotelsByUser(int userId)
        //{
        //    User user = _context.Users.FirstOrDefault(u => u.Id == userId);

        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(user.FavoriteHotels);
        //}

        // GET: api/FavoriteHotels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FavoriteHotel>>> GetFavoriteHotel(int userId)
        {
            List<Hotel> favoriteHotels = await _context.FavoriteHotel
                   .Where(fh => fh.UserId == userId)
                   .Select(fh => fh.Hotel)
                   .ToListAsync();

            if (favoriteHotels == null || favoriteHotels.Count == 0)
            {
                return NotFound();
            }

            return Ok(favoriteHotels);
        }

        [HttpGet("CheckIfHotelIsFavorite")]
        public async Task<IActionResult> CheckIfHotelIsFavorite(int userId, int hotelId)
        {
            User user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                return NotFound();
            }

            bool isFavorite = await _context.FavoriteHotel
                .AnyAsync(fh => fh.UserId == userId && fh.HotelId == hotelId);

            return Ok(isFavorite.ToString());
        }

        // GET: api/FavoriteHotels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FavoriteHotel>> GetFavoriteHotelById(int id)
        {
          if (_context.FavoriteHotel == null)
          {
              return NotFound();
          }
            var favoriteHotel = await _context.FavoriteHotel.FindAsync(id);

            if (favoriteHotel == null)
            {
                return NotFound();
            }

            return favoriteHotel;
        }

        // PUT: api/FavoriteHotels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFavoriteHotel(int id, FavoriteHotel favoriteHotel)
        {
            if (id != favoriteHotel.Id)
            {
                return BadRequest();
            }

            _context.Entry(favoriteHotel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FavoriteHotelExists(id))
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

        // POST: api/FavoriteHotels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
       
        [HttpPost("AddFavoriteHotel")]
        public async Task<ActionResult<FavoriteHotel>> PostFavoriteHotel(int userId, int hotelId)
        {
            FavoriteHotel fav = new();
            fav.UserId = userId;
            fav.HotelId = hotelId;
            _context.FavoriteHotel.Add(fav);
            await _context.SaveChangesAsync();

            return Ok("Succes!");
        }

        [HttpDelete("DeleteFavoriteHotel")]
        public async Task<IActionResult> RemoveFavoriteHotel(int userId, int hotelId)
        {
            FavoriteHotel favoriteHotel = await _context.FavoriteHotel
                .FirstOrDefaultAsync(fh => fh.UserId == userId && fh.HotelId == hotelId);

            if (favoriteHotel == null)
            {
                return NotFound();
            }

            _context.FavoriteHotel.Remove(favoriteHotel);
            await _context.SaveChangesAsync();

            return Ok("Succes!");
        }

        // DELETE: api/FavoriteHotels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFavoriteHotel(int id)
        {
            if (_context.FavoriteHotel == null)
            {
                return NotFound();
            }
            var favoriteHotel = await _context.FavoriteHotel.FindAsync(id);
            if (favoriteHotel == null)
            {
                return NotFound();
            }

            _context.FavoriteHotel.Remove(favoriteHotel);
            await _context.SaveChangesAsync();

            return Ok("Succes!");
        }

        private bool FavoriteHotelExists(int id)
        {
            return (_context.FavoriteHotel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
