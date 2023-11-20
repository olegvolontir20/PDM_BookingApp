using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookingApplication.DAL;
using BookingApplication.Entities.Models;
using BookingApplication.Entities.Pagination;
using Microsoft.AspNetCore.Authorization;
using BookingApplication.Entities;
using System.Linq;

namespace BookingApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartamentsController : ControllerBase
    {
        private readonly DataContext _context;

        public ApartamentsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Apartaments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Apartament>>> GetApartaments([FromQuery] PaginationFilter filter)
        {
            var validPageFilter = new PaginationFilter(filter.per_page, filter.current_page);
            var apartamentData = await _context.Apartaments.Include(x => x.Reviews).ThenInclude(x => x.User)
                .Skip((validPageFilter.current_page - 1) * validPageFilter.per_page)
                .Take(validPageFilter.per_page)
                .ToListAsync();

            var countTotal = await _context.Apartaments.CountAsync();

            return Ok(new PaginatedResponse<List<Apartament>>(countTotal, validPageFilter.per_page, validPageFilter.current_page, apartamentData));
        }

        // GET: api/Apartaments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Apartament>> GetApartament(int id)
        {
            if (_context.Apartaments == null)
            {
                return NotFound();
            }
            var apartament = await _context.Apartaments.Include(x => x.Reviews).ThenInclude(x => x.User).FirstOrDefaultAsync(i => i.Id == id);

            if (apartament == null)
            {
                return NotFound();
            }

            return apartament;
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Apartament>>> SearchFilterAndSortApartaments([FromQuery] BookModel bookModel)
        {
            List<Apartament> apartaments = new();
            try
            {
                apartaments = await _context.Apartaments
                            .Include(a => a.ApartamentBookings)
                            .Where(a => a.Country == bookModel.Country && a.City == bookModel.City)
                            .Where(a => a.Capacity >= int.Parse(bookModel.Capacity))
                            .ToListAsync();
                List<Apartament> availableApartaments = new();
                foreach (var apartament in apartaments)
                {              
                    var apartamentBookings = await _context.ApartamentBookings.ToListAsync();
                    bool isBooked = false;

                    foreach (var apartamentBooking in apartamentBookings)
                    {
                        if (apartamentBooking.Ap_Id == apartament.Id)
                        {
                            if (bookModel.StartDate <= apartamentBooking.LastDay.Date && bookModel.EndDate >= apartamentBooking.FirstDay.Date)
                            {
                                isBooked = true;
                                break;
                            }
                        }
                    }

                    if (!isBooked)
                    {
                        availableApartaments.Add(apartament);
                    }         
                }
                apartaments = availableApartaments;
            }
            catch(Exception ex)
            {
                throw ex;
            }

            //if(apartaments.Count() > 0)
            //{
            //    apartaments = apartaments.ToList();
            //}

            apartaments = apartaments.OrderBy(a => a.Name).ToList();

            return Ok(apartaments);

        }

        [HttpGet("last-three")]
        public async Task<ActionResult<Apartament>> GetLastThreeLocations()
        {
            try
            {
                var lastThreeApartaments = _context.Apartaments
                    .OrderByDescending(a => a.Id)
                    .Take(3)
                    .ToList();

                return Ok(lastThreeApartaments);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while retrieving locations.");
            }
        }

        // PUT: api/Apartaments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutApartament(int id, Apartament apartament)
        {
            if (id != apartament.Id)
            {
                return BadRequest();
            }

            _context.Entry(apartament).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApartamentExists(id))
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

        // POST: api/Apartaments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Apartament>> PostApartament(Apartament apartament)
        {
          if (_context.Apartaments == null)
          {
              return Problem("Entity set 'DataContext.Apartaments'  is null.");
          }
            _context.Apartaments.Add(apartament);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetApartament", new { id = apartament.Id }, apartament);
        }

        // DELETE: api/Apartaments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApartament(int id)
        {
            if (_context.Apartaments == null)
            {
                return NotFound();
            }
            var apartament = await _context.Apartaments.FindAsync(id);
            if (apartament == null)
            {
                return NotFound();
            }

            _context.Apartaments.Remove(apartament);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ApartamentExists(int id)
        {
            return (_context.Apartaments?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}