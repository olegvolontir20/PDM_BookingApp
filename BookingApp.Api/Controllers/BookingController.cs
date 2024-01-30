using AutoMapper;
using BookingApp.DAL.DTO;
using BookingApp.Domain.Interfaces;
using BookingApp.Domain.Models.ApiRequests;
using BookingApp.Domain.Models.Entities;
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

            var res = await _bookingService.PostApartmentBooking(apartamentBooking, userId);

            return CreatedAtAction("PostApartmentBooking", new { id = res.Id }, res);
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

            var res = await _bookingService.PostRoomBooking(roomBooking, userId);

            return CreatedAtAction("PostRoomBooking", new { id = res.Id }, res);
        }


    }
}
