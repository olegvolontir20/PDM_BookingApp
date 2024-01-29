using AutoMapper;
using BookingApp.DAL.DTO;
using BookingApp.Domain.Interfaces;
using BookingApp.Domain.Models.ApiRequests;
using BookingApp.Domain.Models.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BookingApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        //private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly UserManager<UserDTO> _userManager;
        public UserController(/*IUserService userService, */IMapper mapper, UserManager<UserDTO> userManager)
        {
            //_userService = userService;
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserSignUpModel userSignUpModel)
        {
            var user = _mapper.Map<UserDTO>(userSignUpModel);

            var result = await _userManager.CreateAsync(user, userSignUpModel.Password);

            if (!result.Succeeded)
            {
                try
                {
                    var err = result.Errors.First();
                    return BadRequest(err.Description);
                }
                catch
                {
                    return BadRequest();
                }                           
            }

            await _userManager.AddToRoleAsync(user, "Regular");

            return Ok();
        }

        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> Login(UserSignInModel model)
        {
            var user = await _userManager.FindByNameAsync(model.Name);

            if (user != null &&
                await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var identity = new ClaimsIdentity(IdentityConstants.ApplicationScheme);
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
                identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
                await HttpContext.SignInAsync(IdentityConstants.ApplicationScheme,
                    new ClaimsPrincipal(identity));
                return Ok();
            }
            else
            {
                return BadRequest(new Exception("Wrong user name or password"));
            }
        }
    }
}
