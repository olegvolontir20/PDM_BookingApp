using BookingApplication.Entities;
using BookingApplication.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingApplication.DAL
{
    public class HotelsRepository : IHotelsRepository
    {
        private readonly DataContext _context;


        public HotelsRepository(DataContext context)
        {
            _context = context;
        }



        public async Task<List<Hotel>> GetHotels()
        {
            var hotelData = await _context.Hotels
                .Include(x => x.Reviews)
                .ToListAsync();

            return hotelData;
        }
        public async Task<Hotel> GetHotelById(int id)
        {
            var hotelData = await _context.Hotels
                .Include(x => x.Reviews)
                .ThenInclude(x => x.User)
                .FirstOrDefaultAsync(x => x.Id == id);

            return hotelData;


        }

        public async Task<List<Hotel>> SearchFilterAndSortHotels(BookModel bookModel)
        {
            var hotelData = await _context.Hotels
                .Include(h => h.Rooms)
                .Include(h => h.RoomBookings)
                .Where(h => h.Country == bookModel.Country && h.City == bookModel.City)
                .Where(h => h.Rooms.Any(r => r.Capacity >= int.Parse(bookModel.Capacity)))
                .ToListAsync();

            return hotelData;
        }

        public async Task<List<RoomBooking>> GetHotelBookings()
        {
            return await _context.RoomBookings.ToListAsync();

        }

    }
}
