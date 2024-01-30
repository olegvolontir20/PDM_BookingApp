using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookingApp.DAL.DTO;
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
        private readonly IMapper _mapper;

        public HotelRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ICollection<Hotel>> GetHotels() 
        {
            var hotelData = await _context.Hotels
                .Include(x => x.Rooms)
                .ToListAsync();

            return _mapper.Map<ICollection<Hotel>>(hotelData);
        }

        public async Task<ICollection<Hotel>> SearchFilterAndSortHotels(SearchBookingModel bookModel)
        {
            var hotels = await _context.Hotels
                            .Include(h => h.Rooms)
                            .Where(h => h.Country == bookModel.Country && h.City == bookModel.City)
                            .Where(h => h.Rooms.Any(r => r.Capacity >= int.Parse(bookModel.Capacity)))
                            .ToListAsync();

            return _mapper.Map<ICollection<Hotel>>(hotels);
        }

        public async Task<ICollection<Hotel>> GetLastThreeLocations()
        {
            var lastThreeHotels = await _context.Hotels
                .OrderByDescending(h => h.Id)
                .Take(3)
                .ToListAsync();

            return _mapper.Map<ICollection<Hotel>>(lastThreeHotels);
        }

        public async Task<Hotel> GetHotel(int id)
        {
            var hotelData = await _context.Hotels
                .Include(x => x.Rooms)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            return _mapper.Map<Hotel>(hotelData);
        }

        public async Task PutHotel(Hotel hotel)
        {
            var changedHotel = _mapper.Map<HotelDTO>(hotel);
            _context.Entry(changedHotel).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        public async Task<Hotel> PostHotel(Hotel hotel)
        {
            var res = _context.Hotels.Add(_mapper.Map<HotelDTO>(hotel));
            await _context.SaveChangesAsync();

            return _mapper.Map<Hotel>(res.Entity);
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

        public async Task<ICollection<Room>> GetRooms(int hotelId)
        {
            var roomData = await _context.Rooms
                .Where(x => x.Hotel_Id == hotelId)
                .ToListAsync();

            return _mapper.Map<ICollection<Room>>(roomData);
        }

        public async Task<Room> GetRoom(int roomId)
        {
            var roomData = await _context.Rooms
                .Include(x => x.Hotel)
                .Where(x => x.Id == roomId)
                .FirstOrDefaultAsync();

            return _mapper.Map<Room>(roomData);
        }
    }
}
