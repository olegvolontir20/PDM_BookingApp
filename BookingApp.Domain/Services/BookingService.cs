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
        private readonly IApartmentRepository _apartmentRepository;
        private readonly IHotelRepository _hotelRepository;
        private readonly IMapper _mapper;

        public BookingService(IBookingRepository repository, IApartmentRepository apartmentRepository, IHotelRepository hotelRepository, IMapper mapper)
        {
            _hotelRepository = hotelRepository;
            _apartmentRepository = apartmentRepository;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ICollection<ApartmentBooking>> GetApartmentBookings(int apartmentId)
        {
            var res = await _repository.GetApartmentBookings(apartmentId);

            return res;
        }

        public async Task<ICollection<RoomBooking>> GetRoomBookings(int roomId)
        {
            var res = await _repository.GetRoomBookings(roomId);

            return res;
        }

        public async Task<ICollection<ApartmentBooking>> GetUserApartmentBookings(int userId)
        {
            var res = await _repository.GetUserApartmentBookings(userId);

            return res;
        }

        public async Task<ICollection<RoomBooking>> GetUserRoomBookings(int userId)
        {
            var res =  await _repository.GetUserRoomBookings(userId);

            return res;
        }

        public async Task<ApartmentBooking> PostApartmentBooking(AddApartmentBookingModel booking, int userId)
        {
            if (booking.LastDay < booking.FirstDay)
            {
                throw new Exception("Invalid booking time interval");
            }

            var apartment = await _apartmentRepository.GetApartmentById(booking.Ap_Id);

            if (booking.NumberOfPeople <= 0 && booking.NumberOfPeople > apartment.Capacity)
            {
                throw new Exception("Requested nr. of people is over or under the capacity");
            }

            var bookings = await _repository.GetApartmentBookings(booking.Ap_Id);

            foreach (var b in bookings)
            {
                if (booking.FirstDay <= b.LastDay)
                {
                    throw new Exception("Can't book for provided datetime");
                }
            }

            var apartmentBooking = _mapper.Map<ApartmentBooking>(booking);
            apartmentBooking.User_Id = userId;

            var res = await _repository.PostApartmentBooking(apartmentBooking);

            if (res == null)
            {
                throw new Exception("Post Failed");
            }

            return res;
        }

        //Hotel booking
        public async Task<RoomBooking> PostRoomBooking(AddRoomBookingModel booking, int userId)
        {
            if(booking.LastDay < booking.FirstDay)
            {
                throw new Exception("Invalid booking time interval");
            }

            var room = await _hotelRepository.GetRoom(booking.Room_Id);

            if (booking.NumberOfPeople <= 0 && booking.NumberOfPeople > room.Capacity)
            {
                throw new Exception("Requested nr. of people is over or under the capacity");
            }

            var roomBookings = await _repository.GetRoomBookings(booking.Room_Id);

            foreach (var b in roomBookings)
            {
                if (booking.FirstDay <= b.LastDay)
                {
                    throw new Exception("Can't book for provided datetime");
                }
            }

            var roomBooking = _mapper.Map<RoomBooking>(booking);
            roomBooking.User_Id = userId;

            var res = await _repository.PostRoomBooking(roomBooking);

            if (res == null)
            {
                throw new Exception("Post Failed");
            }

            return res;
        }

        public async Task DeleteApartmentBooking(int id, int userId)
        {
            var booking = await _repository.GetApartmentBooking(id);

            if(booking.User_Id != userId)
            {
                throw new Exception("Not authorized");
            }

            await _repository.DeleteApartmentBooking(booking.Id);
        }

        public async Task DeleteRoomBooking(int id, int userId)
        {
            var booking = await _repository.GetRoomBooking(id);


            if (booking.User_Id != userId)
            {
                throw new Exception("Not authorized");
            }

            await _repository.DeleteRoomBooking(booking.Id);
        }

    }
}
