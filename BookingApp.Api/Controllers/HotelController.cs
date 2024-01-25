using AutoMapper;
using BookingApp.Domain.Interfaces;
using BookingApp.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookingApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : Controller
    {
        //private readonly IHotelService _hotelService;
        private readonly IMapper _mapper;

        public HotelController(/*IHotelService hotelService,*/ IMapper mapper)
        {
            //_hotelService = hotelService;
            _mapper = mapper;
        }
    }
}
