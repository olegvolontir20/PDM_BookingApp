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

        public async Task<Apartament> GetApartamentById(int id)
        {
            var apartamentData = await _context.Apartaments
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();

            return apartamentData;
        }

        public async Task<List<Apartament>> GetApartaments()
        {
            var apartamentData = await _context.Apartaments
                .Include(x => x.Reviews)
                .ToListAsync();

            return apartamentData;
        }

        public async Task<List<Apartament>> SearchFilterAndSortApartaments(BookModel bookModel)
        {
            
            var apartamentData = await _context.Apartaments
                        .Include(a => a.ApartamentBookings)
                        .Where(a => a.Country == bookModel.Country && a.City == bookModel.City)
                        .Where(a => a.Capacity >= int.Parse(bookModel.Capacity))
                        .ToListAsync();

            return apartamentData;
        }

        public async Task<List<ApartamentBooking>> GetApartamentBookings()
        {
            return await _context.ApartamentBookings.ToListAsync();

        }
    }
}
