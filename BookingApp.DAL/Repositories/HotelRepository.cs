using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingApp.Domain.Interfaces;
using BookingApp.Domain.Models.ApiRequests;
using BookingApp.Domain.Models.ApiResponses;
using BookingApp.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookingApp.DAL.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        private readonly DataContext _context;

        public HotelRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Hotel>> GetHotels() 
        {
            var hotelData = await _context.Hotels
                .Include(x => x.Reviews)
                .ToListAsync();

            return hotelData;
        }

        public async Task<IEnumerable<Hotel>> SearchFilterAndSortHotels(BookingModel bookModel)
        {
            var hotels = await _context.Hotels
                            .Include(h => h.Rooms)
                            .Include(h => h.RoomBookings)
                            .Where(h => h.Country == bookModel.Country && h.City == bookModel.City)
                            .Where(h => h.Rooms.Any(r => r.Capacity >= int.Parse(bookModel.Capacity)))
                            .ToListAsync();

            return hotels;
        }

        public async Task<IEnumerable<RoomBooking>> GetRoomBookings()
        {
            return await _context.RoomBookings.ToListAsync();
        }

        public async Task<IEnumerable<Hotel>> GetLastThreeLocations()
        {
            var lastThreeHotels = _context.Hotels
                .OrderByDescending(h => h.Id)
                .Take(3)
                .ToList();

            return lastThreeHotels;
        }

        public async Task<Hotel> GetHotel(int id)
        {
            var hotelData = await _context.Hotels
                .Include(x=>x.Reviews)
                .ThenInclude(x => x.User)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            return hotelData;
        }

        public async Task PutHotel(Hotel hotel)
        {
            _context.Entry(hotel).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        public async Task<Hotel> PostHotel(Hotel hotel)
        {
            var res = _context.Hotels.Add(hotel);
            await _context.SaveChangesAsync();

            return res.Entity;
        }

        public async Task DeleteHotel(int id)
        {
            var hotel = await _context.Hotels.FindAsync(id);
            if (hotel == null)
            {
                throw new Exception($"Apartment with id {id} not found");
            }

            _context.Hotels.Remove(hotel);
            await _context.SaveChangesAsync();
        }
    }
}
