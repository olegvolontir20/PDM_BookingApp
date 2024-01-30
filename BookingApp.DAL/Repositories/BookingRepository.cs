using AutoMapper;
using BookingApp.DAL.DTO;
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
    public class BookingRepository : IBookingRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public BookingRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ApartmentBooking> GetApartmentBooking(int bookingId)
        {
            var res = await _context.ApartmentBookings
                .Where(x => x.Id == bookingId)
                .FirstOrDefaultAsync();

            return _mapper.Map<ApartmentBooking>(res);
        }

        public async Task<RoomBooking> GetRoomBooking(int bookingId)
        {
            var res = await _context.RoomBookings
                .Where(x => x.Id == bookingId)
                .FirstOrDefaultAsync();

            return _mapper.Map<RoomBooking>(res);
        }

        public async Task<ApartmentBooking> PostApartmentBooking(ApartmentBooking booking)
        {
            var res = _context.ApartmentBookings.Add(_mapper.Map<ApartmentBookingDTO>(booking));
            await _context.SaveChangesAsync();

            return _mapper.Map<ApartmentBooking>(res.Entity);
        }

        public async Task<RoomBooking> PostRoomBooking(RoomBooking booking)
        {
            var res = _context.RoomBookings.Add(_mapper.Map<RoomBookingDTO>(booking));
            await _context.SaveChangesAsync();

            return _mapper.Map<RoomBooking>(res.Entity);
        }

        public async Task<ICollection<ApartmentBooking>> GetApartmentBookings(int apartmentId)
        {
            var res = await _context.ApartmentBookings
                .Where(x => x.Id == apartmentId)
                .ToListAsync();

            return _mapper.Map<ICollection<ApartmentBooking>>(res);
        }


        public async Task<ICollection<RoomBooking>> GetRoomBookings(int roomId)
        {
            var bookings = await _context.RoomBookings
                .Where(x => x.Id == roomId)
                .ToListAsync();

            return _mapper.Map<ICollection<RoomBooking>>(bookings);
        }

        public async Task<ICollection<ApartmentBooking>> GetUserApartmentBookings(int userId)
        {
            var res = await _context.ApartmentBookings
                .Where(x => x.User_Id == userId)
                .ToListAsync();

            return _mapper.Map<ICollection<ApartmentBooking>>(res);
        }

        public async Task<ICollection<RoomBooking>> GetUserRoomBookings(int userId)
        {
            var bookings = await _context.RoomBookings
                .Where(x => x.User_Id == userId)
                .ToListAsync();

            return _mapper.Map<ICollection<RoomBooking>>(bookings);
        }

        public async Task DeleteRoomBooking(int id)
        {
            var booking = await _context.RoomBookings.FindAsync(id);
            if (booking == null)
            {
                throw new Exception($"Booking with id {id} not found");
            }

            _context.RoomBookings.Remove(booking);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteApartmentBooking(int id)
        {
            var booking = await _context.ApartmentBookings.FindAsync(id);
            if (booking == null)
            {
                throw new Exception($"Booking with id {id} not found");
            }

            _context.ApartmentBookings.Remove(booking);
            await _context.SaveChangesAsync();
        }

    }
}
