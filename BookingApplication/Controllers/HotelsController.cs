using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookingApplication.DAL;
using BookingApplication.Entities.Models;
using BookingApplication.Entities.Pagination;
using Microsoft.AspNetCore.Authorization;
using BookingApplication.Entities;
using System.Threading.Tasks;
using System.Linq;
using BookingApplication.Services;

namespace BookingApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelsService _hotelsService;

        public HotelsController(IHotelsService hotelsService)
        {
            _hotelsService = hotelsService ?? throw new ArgumentNullException(nameof(hotelsService));
        }

        // GET: api/Hotels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetHotels([FromQuery] PaginationFilter filter)
        {
            var validPageFilter = new PaginationFilter(filter.per_page, filter.current_page);
            var hotelData = await _hotelsService.GetHotels();

            return Ok(new PaginatedResponse<List<Hotel>>(hotelData.count, validPageFilter.per_page, validPageFilter.current_page, hotelData.Hotels));
        }


        //private bool HasOverlappingBooking(List<Room> rooms, DateTime startDate, DateTime endDate)
        //{
        //    if (rooms != null)
        //    {

        //        rooms.Where(rb => rb.Room_Id == room.Id)
        //        foreach (var room in rooms)
        //        {

        //            if (startDate <= roomBooking.LastDay.Date && endDate.Date >= roomBooking.FirstDay.Date)
        //            {
        //                return true; //exista suprapuneri
        //            }
        //        }
        //    }
        //    return false; //nu exista
        //}

        // GET: api/Hotels
               [HttpGet("search")]
                public async Task<ActionResult<IEnumerable<Hotel>>> SearchFilterAndSortHotels([FromQuery] BookModel bookModel)
                {

                    var hotelData = await _hotelsService.SearchFilterAndSortHotels(bookModel);


                    if (hotelData == null)
                    {
                        return NotFound();
                    }
                    else return Ok(hotelData);

                }
        /*
                       [HttpGet("last-three")]
                       public async Task<ActionResult<Hotel>> GetLastThreeLocations()
                       {
                           try
                           {
                               var lastThreeHotels = _context.Hotels
                                   .OrderByDescending(h => h.Id)
                                   .Take(3)
                                   .ToList();

                               return Ok(lastThreeHotels);
                           }
                           catch (Exception ex)
                           {
                               return StatusCode(500, "An error occurred while retrieving locations.");
                           }
                       } */

        //        GET: api/Hotels/5
        [HttpGet("{id}")]
                public async Task<ActionResult<Hotel>> GetHotel([FromRoute] int id)
                {
                    var hotel = await _hotelsService.GetHotelById(id);
                    if (hotel == null)
                    {
                        return NotFound();
                    }

                    return Ok(hotel);
                }
        /*
                PUT: api/Hotels/5
                 To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
                [HttpPut("{id}")]
                public async Task<IActionResult> PutHotel(int id, Hotel hotel)
                {
                    if (id != hotel.Id)
                    {
                        return BadRequest();
                    }

                    _context.Entry(hotel).State = EntityState.Modified;

                    try
                    {
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!HotelExists(id))
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

                POST: api/Hotels
                To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
                [HttpPost]
                public async Task<ActionResult<Hotel>> PostHotel(Hotel hotel)
                {
                    if (_context.Hotels == null)
                    {
                        return Problem("Entity set 'DataContext.Hotels'  is null.");
                    }
                    _context.Hotels.Add(hotel);
                    await _context.SaveChangesAsync();

                    return CreatedAtAction("GetHotel", new { id = hotel.Id }, hotel);
                }

                DELETE: api/Hotels/5
                [HttpDelete("{id}")]
                public async Task<IActionResult> DeleteHotel(int id)
                {
                    if (_context.Hotels == null)
                    {
                        return NotFound();
                    }
                    var hotel = await _context.Hotels.FindAsync(id);
                    if (hotel == null)
                    {
                        return NotFound();
                    }

                    _context.Hotels.Remove(hotel);
                    await _context.SaveChangesAsync();

                    return NoContent();
                }

                private bool HotelExists(int id)
                {
                    return (_context.Hotels?.Any(e => e.Id == id)).GetValueOrDefault();
                }
            }*/
    }
}
