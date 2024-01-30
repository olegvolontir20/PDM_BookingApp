using AutoMapper;
using BookingApp.Domain.Interfaces;
using BookingApp.Domain.Models.ApiRequests;
using BookingApp.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Domain.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _repository;
        private readonly IMapper _mapper;

        public BookingService(IBookingRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ApartmentBooking> PostApartmentBooking(AddApartmentBookingModel booking, int userId)
        {
            var apartmentBooking = _mapper.Map<ApartmentBooking>(booking);
            apartmentBooking.User_Id = userId;

            var res = await _repository.PostApartmentBooking(apartmentBooking);

            if (res == null)
            {
                throw new Exception("Post Failed");
            }

            return res;
        }

        public async Task<RoomBooking> PostRoomBooking(AddRoomBookingModel booking, int userId)
        {
            var roomBooking = _mapper.Map<RoomBooking>(booking);
            roomBooking.User_Id = userId;

            var res = await _repository.PostRoomBooking(roomBooking);

            if (res == null)
            {
                throw new Exception("Post Failed");
            }

            return res;
        }
    }
}
