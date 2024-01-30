using AutoMapper;
using BookingApp.Domain.Interfaces;
using BookingApp.Domain.Models.ApiRequests;
using BookingApp.Domain.Models.ApiResponses;
using BookingApp.Domain.Models.Entities;
using BookingApp.Domain.Models.ServiceResult;
using BookingApp.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookingApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _hotelService;
        private readonly IMapper _mapper;

        public HotelController(IHotelService hotelService, IMapper mapper)
        {
            _hotelService = hotelService;
            _mapper = mapper;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<HotelResponse>> GetHotel([FromRoute] int id)
        {
            var hotel = await _hotelService.GetHotel(id);
            if (hotel == null)
            {
                return NotFound();
            }
            return Ok(hotel);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelResponse>>> GetHotels([FromQuery] PaginationFilter filter)
        {
            var validPageFilter = new PaginationFilter(filter.PerPage, filter.CurrentPage);
            var hotelData = await _hotelService.GetHotels();

            return Ok(new PaginatedResponse<IEnumerable<HotelResponse>>(hotelData.Count(), validPageFilter.PerPage, validPageFilter.CurrentPage, hotelData));
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<HotelResponse>>> SearchFilterAndSortHotels([FromQuery] SearchBookingModel bookModel)
        {
            var hotelData = await _hotelService.SearchFilterAndSortHotels(bookModel);

            if (hotelData == null)
            {
                return NotFound();
            }
            else return Ok(hotelData);
        }

        [HttpGet("last-three")]
        public async Task<ActionResult<HotelResponse>> GetLastThreeLocations()
        {
            try
            {
                var lastThreeHotels = await _hotelService.GetLastThreeLocations();

                return Ok(lastThreeHotels);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotel(int id, Hotel hotel)
        {
            if (id != hotel.Id)
            {
                return BadRequest();
            }

            try
            {
                await _hotelService.PutHotel(id, hotel);
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Hotel>> PostHotel(HotelAddModel hotel)
        {
            var res = await _hotelService.PostHotel(hotel);

            return CreatedAtAction("PostHotel", new { id = res.Id }, res);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            try
            {
                await _hotelService.DeleteHotel(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return NoContent();
        }
    }
}
