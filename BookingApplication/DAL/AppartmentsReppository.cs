using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookingApplication.DAL;
using BookingApplication.Entities.Models;
using BookingApplication.Entities.Pagination;
using Microsoft.AspNetCore.Authorization;
using BookingApplication.Entities;
using System.Linq;

namespace BookingApplication.DAL
{
    public class AppartmentsReppository : IAppartmentResppository
    {
        private readonly DataContext _context;


        public AppartmentsReppository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Apartament>> GetApartaments()
        {
            var apartamentData = await _context.Apartaments
                .Include(x => x.Reviews)
                .ToListAsync();

            return apartamentData;
        }
    }
}
