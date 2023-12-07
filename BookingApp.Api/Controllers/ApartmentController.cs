using BookingApp.Domain.Interfaces;
using BookingApp.Domain.Models;
using BookingApp.Domain.Models.ApiRequests;
using BookingApp.Domain.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookingApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartmentController : ControllerBase
    {
        private readonly IApartmentService _apartmentService;

        public ApartmentController(IApartmentService apartmentService)
        {
            _apartmentService = apartmentService;
        }

        // GET: api/Apartment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Apartment>>> GetApartments([FromQuery] PaginationFilter filter)
        {
            var validPageFilter = new PaginationFilter(filter.PerPage, filter.CurrentPage);
            var apartamentData = await _apartmentService.GetApartments();

            return Ok(new PaginatedResponse<List<Apartment>>(apartamentData.Count, validPageFilter.PerPage, validPageFilter.CurrentPage, apartamentData.Apartments));
        }

        // get: api/apartment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Apartment>> GetApartament(int id)
        {
            var apartment = await _apartmentService.GetApartment(id);
            if (apartment == null)
            {
                return NotFound();
            }
            return Ok(apartment);
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Apartment>>> SearchFilterAndSortApartaments([FromQuery] BookingModel bookmodel)
        {
            var apartmentData = await _apartmentService.SearchFilterAndSortApartments(bookmodel);

            if (apartmentData == null)
            {
                return NotFound();
            }
            else return Ok(apartmentData);
        }
    }
}
