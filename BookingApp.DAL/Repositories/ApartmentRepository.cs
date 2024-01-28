using AutoMapper;
using BookingApp.DAL.DTO;
using BookingApp.Domain.Interfaces;
using BookingApp.Domain.Models.ApiRequests;
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
        private readonly IMapper _mapper;

        public ApartmentRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Apartment> GetApartmentById(int id)
        {
            var apartmentData = await _context.Apartments
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();

            return _mapper.Map<Apartment>(apartmentData);
        }

        public async Task<IEnumerable<Apartment>> GetApartments()
        {
            var apartmentData = await _context.Apartments
                .Include(x => x.Reviews)
                .ToListAsync();
            return _mapper.Map<IEnumerable<Apartment>>(apartmentData);
        }

        public async Task<IEnumerable<Apartment>> SearchFilterAndSortApartments(BookingModel bookModel)
        {
            var apartmentData = await _context.Apartments
                        .Include(a => a.ApartmentBookings)
                        .Where(a => a.Country == bookModel.Country && a.City == bookModel.City)
                        .Where(a => a.Capacity >= int.Parse(bookModel.Capacity))
                        .ToListAsync();
            return _mapper.Map<IEnumerable<Apartment>>(apartmentData);
        }

        public async Task<IEnumerable<ApartmentBooking>> GetApartmentBookings()
        {
            var apartmentData = await _context.ApartmentBookings.ToListAsync();
            return _mapper.Map<IEnumerable<ApartmentBooking>>(apartmentData);
        }

        public async Task<IEnumerable<Apartment>> GetLastThreeLocations()
        {
                var lastThreeApartments = await _context.Apartments
                    .OrderByDescending(a => a.Id)
                    .Take(3)
                    .ToListAsync();

                return _mapper.Map<IEnumerable<Apartment>>(lastThreeApartments);
        }

        public async Task PutApartment(Apartment apartment)
        {
            var changedApartment = _mapper.Map<ApartmentDTO>(apartment);
            _context.Entry(changedApartment).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        public async Task<Apartment> PostApartment(Apartment apartment)
        {
            var res = _context.Apartments.Add(_mapper.Map<ApartmentDTO>(apartment));
            await _context.SaveChangesAsync();

            return _mapper.Map<Apartment>(res.Entity);
        }

        public async Task DeleteApartment(int id)
        {
            var apartment = await _context.Apartments.FindAsync(id);
            if (apartment == null)
            {
                throw new Exception($"Apartment with id {id} not found");
            }

            _context.Apartments.Remove(apartment);
            await _context.SaveChangesAsync();
        }
    }
}
