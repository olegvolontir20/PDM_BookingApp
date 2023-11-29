using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookingApplication.DAL;
using BookingApplication.Entities.Models;
using BookingApplication.Entities.Pagination;
using Microsoft.AspNetCore.Authorization;
using BookingApplication.Entities;
using System.Linq;
using BookingApplication.Services;

namespace BookingApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartamentsController : ControllerBase
    {
        private readonly IAppartmentService _appartmentsService;

        public ApartamentsController(IAppartmentService appartmentsService)
        {
            _appartmentsService = appartmentsService;
        }

        // GET: api/Apartaments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Apartament>>> GetApartaments([FromQuery] PaginationFilter filter)
        {
            var validPageFilter = new PaginationFilter(filter.per_page, filter.current_page);
            var apartamentData = await _appartmentsService.GetApartaments();

            return Ok(new PaginatedResponse<List<Apartament>>(apartamentData.count, validPageFilter.per_page, validPageFilter.current_page, apartamentData.Apartaments));
        }

        // get: api/apartaments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Apartament>> GetApartament(int id)
        {
            var apartament = await _appartmentsService.GetApartament(id);
            if (apartament == null)
            {
                return NotFound();
            }
            return Ok(apartament);
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Apartament>>> SearchFilterAndSortApartaments([FromQuery] BookModel bookmodel)
        {
           

            var apartamentData = await _appartmentsService.SearchFilterAndSortApartaments(bookmodel);
            

            if (apartamentData == null)
            {
                return NotFound();
            }else return Ok(apartamentData);

        }

        /*        [HttpGet("search")]
                public async Task<ActionResult<IEnumerable<Apartament>>> searchfilterandsortapartaments([FromQuery] BookModel bookmodel)
                {
                    List<Apartament> apartaments = new();
                    try
                    {
                        apartaments = await _context.apartaments
                                    .include(a => a.apartamentbookings)
                                    .where(a => a.country == bookmodel.country && a.city == bookmodel.city)
                                    .where(a => a.capacity >= int.parse(bookmodel.capacity))
                                    .tolistasync();
                        List<Apartament> availableapartaments = new();
                        foreach (var apartament in apartaments)
                        {
                            var apartamentbookings = await _context.apartamentbookings.tolistasync();
                            bool isbooked = false;

                            foreach (var apartamentbooking in apartamentbookings)
                            {
                                if (apartamentbooking.ap_id == apartament.id)
                                {
                                    if (bookmodel.startdate <= apartamentbooking.lastday.date && bookmodel.enddate >= apartamentbooking.firstday.date)
                                    {
                                        isbooked = true;
                                        break;
                                    }
                                }
                            }

                            if (!isbooked)
                            {
                                availableapartaments.add(apartament);
                            }
                        }
                        apartaments = availableapartaments;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                    if (apartaments.Count() > 0)
                    {
                        apartaments = apartaments.ToList();
                    }

                    apartaments = apartaments.OrderBy(a => a.Name).ToList();

                    return Ok(apartaments);

                }*/

        //[HttpGet("last-three")]
        //public async Task<ActionResult<Apartament>> GetLastThreeLocations()
        //{
        //    try
        //    {
        //        var lastThreeApartaments = _context.Apartaments
        //            .OrderByDescending(a => a.Id)
        //            .Take(3)
        //            .ToList();

        //        return Ok(lastThreeApartaments);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, "An error occurred while retrieving locations.");
        //    }
        //}

        //// PUT: api/Apartaments/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutApartament(int id, Apartament apartament)
        //{
        //    if (id != apartament.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(apartament).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ApartamentExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Apartaments
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Apartament>> PostApartament(Apartament apartament)
        //{
        //  if (_context.Apartaments == null)
        //  {
        //      return Problem("Entity set 'DataContext.Apartaments'  is null.");
        //  }
        //    _context.Apartaments.Add(apartament);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetApartament", new { id = apartament.Id }, apartament);
        //}

        //// DELETE: api/Apartaments/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteApartament(int id)
        //{
        //    if (_context.Apartaments == null)
        //    {
        //        return NotFound();
        //    }
        //    var apartament = await _context.Apartaments.FindAsync(id);
        //    if (apartament == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Apartaments.Remove(apartament);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool ApartamentExists(int id)
        //{
        //    return (_context.Apartaments?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}