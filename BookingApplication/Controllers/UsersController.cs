using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookingApplication.DAL;
using BookingApplication.Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using BookingApplication.Common;
using BookingApplication.Entities;

namespace BookingApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
          if (_context.Users == null)
          {
              return NotFound();
          }
            return await _context.Users.Include(x => x.HotelReviews).Include(x => x.ApartamentReviews).ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
          if (_context.Users == null)
          {
              return NotFound();
          }
            var user = await _context.Users.Include(x => x.HotelReviews).Include(x => x.ApartamentReviews).FirstOrDefaultAsync(i => i.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
            //return Ok(user.Select(e => new UserDto);
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> PutUser(int id, UpdateModel user)
        {
            var userToUpdate = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if(userToUpdate == null)
            {
                return BadRequest();
            }

            if(userToUpdate.Password != user.Password)
            {
                return BadRequest("Parola curenta este incorecta!");
            }

            userToUpdate.Name = user.Name;
            userToUpdate.PhoneNumber = user.PhoneNumber;
            if(user.NewPassword != "")
            {
                userToUpdate.Password = user.NewPassword;
            }
            _context.Entry(userToUpdate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            //return (IActionResult)user;
            return Ok("Informatii actualizate cu succes!");
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
          if (_context.Users == null)
          {
              return Problem("Entity set 'DataContext.Users'  is null.");
          }
            //user.Password = CommonMethods.ConvertToEncrypt(user.Password);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        [Route("Login")]
        [HttpPost]
        public async Task<ActionResult<User>> Login(LoginModel model)
        {
            var encryptedPassword = model.Password;
            //modif

            var user = await _context.Users.FirstOrDefaultAsync(u =>
                u.Email == model.Email &&
                u.Password == encryptedPassword
                //modif
            );

            if (user == null)
            {
                return NotFound("Invalid email or password");
            }

            // Returnează utilizatorul autentificat
            return user;
        }

        // POST: api/Users/Register
        [HttpPost("Register")]
        public async Task<ActionResult<User>> Register(User user)
        {
            if (_context.Users == null)
            {
                return Problem("Entity set 'DataContext.Users' is null.");
            }

            // Verifică dacă adresa de email există deja în baza de date
            if (await _context.Users.AnyAsync(u => u.Email == user.Email))
            {
                return Conflict("A user with the same email already exists.");
            }

            // Alte validări și logica specifică înregistrării pot fi adăugate aici

            // De exemplu, puteți adăuga validarea și logica pentru verificarea parolei, trimisul de email de confirmare etc.

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }
 
        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return (_context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
