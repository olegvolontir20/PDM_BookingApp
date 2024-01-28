using AutoMapper;
using BookingApp.Domain.Interfaces;
using BookingApp.Domain.Models.ApiRequests;
using BookingApp.Domain.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookingApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<User>> Register(UserSignUpModel user)
        {
            //var res = 

            //return CreatedAtAction("GetUser", new { id = user.Id }, user);
            throw new NotImplementedException();
        }

        [Route("Login")]
        [HttpPost]
        public async Task<ActionResult<User>> Login(UserSignInModel model)
        {
            throw new NotImplementedException();
        }
    }
}
