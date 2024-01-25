using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace BookingApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        //private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserController(/*IUserService userService,*/ IMapper mapper)
        {
            //_userService = userService;
            _mapper = mapper;
        }
    }
}
