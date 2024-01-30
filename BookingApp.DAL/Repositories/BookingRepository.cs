using AutoMapper;
using BookingApp.DAL.DTO;
using BookingApp.Domain.Interfaces;
using BookingApp.Domain.Models.Entities;
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
    }
}
