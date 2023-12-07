using BookingApp.Domain.Interfaces;
using BookingApp.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.DAL.Repositories
{
    public class ApartmentRepository : IApartmentRepository
    {
        private readonly DataContext _context;

        public ApartmentRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Apartment> GetApartmentById(int id)
        {
            var apartmentData = await _context.Apartments
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();

            return apartmentData;
        }

        public async Task<List<Apartment>> GetApartments()
        {
            var apartmentData = await _context.Apartments
                .Include(x => x.Reviews)
                .ToListAsync();
            return apartmentData;
        }

        //public async Task<List<Apartment>> SearchFilterAndSortApartments(BookModel bookModel)
        //{

        //    var apartmentData = await _context.Apartments
        //                .Include(a => a.ApartmentBookings)
        //                .Where(a => a.Country == bookModel.Country && a.City == bookModel.City)
        //                .Where(a => a.Capacity >= int.Parse(bookModel.Capacity))
        //                .ToListAsync();
        //    return apartmentData;
        //}

        public async Task<List<ApartmentBooking>> GetApartmentBookings()
        {
            return await _context.ApartmentBookings.ToListAsync();
        }
    }
}
