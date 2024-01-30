using AutoMapper;
using BookingApp.DAL.DTO;
using BookingApp.Domain.Interfaces;
using BookingApp.Domain.Models.ApiRequests;
using BookingApp.Domain.Models.ApiResponses;
using BookingApp.Domain.Models.Entities;
using BookingApp.Domain.Models.ServiceResult;
using BookingApp.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BookingApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IMapper _mapper;
        public BookingController(IBookingService bookingService, IMapper mapper)
        {
            _bookingService = bookingService;
            _mapper = mapper;
        }

        [HttpPost("book-apartment")]
        [Authorize]
        public async Task<ActionResult<ApartmentBooking>> PostApartmentBooking(AddApartmentBookingModel apartamentBooking)
        {
            string? userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if(userIdString == null)
            {
                return BadRequest();
            }

            int userId = int.Parse(userIdString);

            try
            {
                var res = await _bookingService.PostApartmentBooking(apartamentBooking, userId);

                return CreatedAtAction("PostApartmentBooking", new { id = res.Id }, res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("book-room")]
        [Authorize]
        public async Task<ActionResult<RoomBooking>> PostRoomBooking(AddRoomBookingModel roomBooking)
        {
            string? userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userIdString == null)
            {
                return BadRequest();
            }

            int userId = int.Parse(userIdString);


            try
            {
                var res = await _bookingService.PostRoomBooking(roomBooking, userId);
                return CreatedAtAction("PostRoomBooking", new { id = res.Id }, res);
            }
            catch (Exception ex)
            { 
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("room-book/{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteRoomBooking(int id)
        {
            string? userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userIdString == null)
            {
                return BadRequest();
            }

            int userId = int.Parse(userIdString);

            try
            {
                await _bookingService.DeleteRoomBooking(id, userId);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return NoContent();
        }

        [HttpDelete("apartment-book/{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteApartmentBooking(int id)
        {
            string? userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userIdString == null)
            {
                return BadRequest();
            }

            int userId = int.Parse(userIdString);

            try
            {
                await _bookingService.DeleteApartmentBooking(id, userId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return NoContent();
        }

        [HttpGet("room-bookings/")]
        public async Task<ActionResult<ICollection<RoomBooking>>> GetRoomBookings([FromQuery] PaginationFilter filter)
        {
            string? userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userIdString == null)
            {
                return BadRequest();
            }

            int userId = int.Parse(userIdString);

            var validPageFilter = new PaginationFilter(filter.PerPage, filter.CurrentPage);
            var bookingData = await _bookingService.GetUserRoomBookings(userId);

            return Ok(new PaginatedResponse<ICollection<RoomBooking>>(bookingData.Count(), validPageFilter.PerPage, validPageFilter.CurrentPage, bookingData));
        }

        [HttpGet("apartment-bookings/")]
        public async Task<ActionResult<ICollection<ApartmentBooking>>> GetApartmentBookings([FromQuery] PaginationFilter filter)
        {
            string? userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userIdString == null)
            {
                return BadRequest();
            }

            int userId = int.Parse(userIdString);

            var validPageFilter = new PaginationFilter(filter.PerPage, filter.CurrentPage);
            var bookingData = await _bookingService.GetUserApartmentBookings(userId);

            return Ok(new PaginatedResponse<ICollection<ApartmentBooking>>(bookingData.Count(), validPageFilter.PerPage, validPageFilter.CurrentPage, bookingData));
        }
    }
}
