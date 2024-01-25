using BookingApp.Domain.Interfaces;
using BookingApp.Domain.Models.ApiRequests;
using BookingApp.Domain.Models.ApiResponses;
using BookingApp.Domain.Models.ServiceResult;
using BookingApp.Domain.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Collections.Generic;
using Eaf.Domain.Repositories;

namespace BookingApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartmentController : ControllerBase
    {
        private readonly IApartmentService _apartmentService;
        private readonly IMapper _mapper;

        public ApartmentController(IApartmentService apartmentService, IMapper mapper)
        {
            _apartmentService = apartmentService;
            _mapper = mapper;
        }

        // GET: api/Apartment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Apartment>>> GetApartments([FromQuery] PaginationFilter filter)
        {
            var validPageFilter = new PaginationFilter(filter.PerPage, filter.CurrentPage);
            var apartamentData = await _apartmentService.GetApartments();

            return Ok(new PaginatedResponse<ApartmentResponseList>(apartamentData.Count, validPageFilter.PerPage, validPageFilter.CurrentPage, apartamentData));
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

        [HttpGet("last-three")]
        public async Task<ActionResult<Apartment>> GetLastThreeLocations()
        {
            try
            {
                var lastThreeApartaments = await _apartmentService.GetLastThreeLocations();

                return Ok(lastThreeApartaments);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutApartament(int id, Apartment apartment)
        {
            if (id != apartment.Id)
            {
                return BadRequest();
            }

            try
            {
                await _apartmentService.PutApartment(id, apartment);
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Apartment>> PostApartment(ApartmentAddModel apartment)
        {
            var res = await _apartmentService.PostApartment(apartment);

            return CreatedAtAction("PostApartment", new { id = res.Id }, res);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApartament(int id)
        {
            try
            {
                await _apartmentService.DeleteApartment(id);
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }

            return NoContent();
        }
    }
}
