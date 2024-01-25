﻿using BookingApp.Domain.Interfaces;
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

        public async Task<List<Apartment>> GetLastThreeLocations()
        {
                var lastThreeApartments = await _context.Apartments
                    .OrderByDescending(a => a.Id)
                    .Take(3)
                    .ToListAsync();

                return lastThreeApartments;
        }

        public async Task PutApartment(int id, Apartment apartment)
        {
            _context.Entry(apartment).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        public async Task<Apartment> PostApartment(Apartment apartment)
        {
            var res = _context.Apartments.Add(apartment);
            await _context.SaveChangesAsync();

            return res.Entity;
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
