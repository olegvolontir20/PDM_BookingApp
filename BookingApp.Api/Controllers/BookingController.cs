using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace BookingApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : Controller
    {
        //private readonly IBookingService _bookingService;
        private readonly IMapper _mapper;
        public BookingController(/*IBookingService bookingService,*/ IMapper mapper)
        {
            //_bookingService = bookingService;
            _mapper = mapper;
        }

    }
}
