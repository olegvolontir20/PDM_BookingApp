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
    public class RoomBookingsController : ControllerBase
    {
        private readonly DataContext _context;

        public RoomBookingsController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("createBooking")]
        public async Task<ActionResult<RoomBooking>> CreateRoomBooking(RoomBooking roomBooking)
        {
            // Validarea datelor de intrare
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                // Salvarea rezervării în baza de date
                _context.RoomBookings.Add(roomBooking);
                await _context.SaveChangesAsync();

                return Ok("Rezervare salvată cu succes!");
                //return CreatedAtAction("GetRoomBooking", new { id = roomBooking.Id }, roomBooking);
            }
            catch (Exception ex)
            {
                // În caz de eroare, întoarce un cod de eroare și mesajul de eroare
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }


        // GET: api/RoomBookings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomBooking>>> GetRoomBookings()
        {
          if (_context.RoomBookings == null)
          {
              return NotFound();
          }
            return await _context.RoomBookings.Include(x => x.User).Include(x => x.Room).ToListAsync();
        }

        // GET: api/RoomBookings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomBooking>> GetRoomBooking(int id)
        {
          if (_context.RoomBookings == null)
          {
              return NotFound();
          }
            var roomBooking = await _context.RoomBookings.Include(x => x.User).Include(x => x.Room).FirstOrDefaultAsync(i => i.Id == id);

            if (roomBooking == null)
            {
                return NotFound();
            }

            return roomBooking;
        }

        // PUT: api/RoomBookings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoomBooking(int id, RoomBooking roomBooking)
        {
            if (id != roomBooking.Id)
            {
                return BadRequest();
            }

            _context.Entry(roomBooking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomBookingExists(id))
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

        // POST: api/RoomBookings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RoomBooking>> PostRoomBooking(RoomBooking roomBooking)
        {
          if (_context.RoomBookings == null)
          {
              return Problem("Entity set 'DataContext.RoomBookings'  is null.");
          }
            _context.RoomBookings.Add(roomBooking);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoomBooking", new { id = roomBooking.Id }, roomBooking);
        }

        // DELETE: api/RoomBookings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoomBooking(int id)
        {
            if (_context.RoomBookings == null)
            {
                return NotFound();
            }
            var roomBooking = await _context.RoomBookings.FindAsync(id);
            if (roomBooking == null)
            {
                return NotFound();
            }

            _context.RoomBookings.Remove(roomBooking);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("DeleteBookingByUser")]
        public async Task<IActionResult> DeleteBookingByUser(int bookingId, int userId)
        {
            var roomBooking = await _context.RoomBookings.FindAsync(bookingId);

            if (roomBooking == null)
            {
                return NotFound(); // Rezervarea nu a fost găsită în baza de date
            }

            if (roomBooking.User_Id != userId)
            {
                return Forbid(); // Utilizatorul nu are dreptul să șteargă această rezervare
            }

            _context.RoomBookings.Remove(roomBooking);
            await _context.SaveChangesAsync();

            return Ok("Succes!");
        }


        [HttpGet("BookingsByUser")]
        public ActionResult<IEnumerable<RoomBooking>> GetBookingsByUser(int userId)
        {
            var currentDate = DateTime.Now;
            var userBookings = _context.RoomBookings
                .Include(booking => booking.Room)
                .ThenInclude(room => room.Hotel)
                .Where(booking => booking.User_Id == userId && booking.FirstDay >= currentDate);

            return Ok(userBookings);
        }

        private bool RoomBookingExists(int id)
        {
            return (_context.RoomBookings?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
