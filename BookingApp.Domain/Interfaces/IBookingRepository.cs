using BookingApp.Domain.Models.ApiRequests;
using BookingApp.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Domain.Interfaces
{
    public interface IBookingRepository
    {
        Task<ApartmentBooking> PostApartmentBooking(ApartmentBooking booking);

        Task<ICollection<ApartmentBooking>> GetApartmentBookings(int apartmentId);

        Task<ApartmentBooking> GetApartmentBooking(int bookingId);

        Task<ICollection<ApartmentBooking>> GetUserApartmentBookings(int userId);

        Task<ICollection<RoomBooking>> GetRoomBookings(int roomId);

        Task<RoomBooking> GetRoomBooking(int bookingId);

        Task<ICollection<RoomBooking>> GetUserRoomBookings(int userId);

        Task<RoomBooking> PostRoomBooking(RoomBooking booking);

        Task DeleteRoomBooking(int id);

        Task DeleteApartmentBooking(int id);
    }
}
