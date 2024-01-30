using BookingApp.Domain.Models.ApiRequests;
using BookingApp.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Domain.Interfaces
{
    public interface IBookingService
    {
        Task<ApartmentBooking> PostApartmentBooking(AddApartmentBookingModel booking, int userId);

        Task<RoomBooking> PostRoomBooking(AddRoomBookingModel booking, int userId);

        Task<ICollection<ApartmentBooking>> GetApartmentBookings(int apartmentId);

        Task<ICollection<ApartmentBooking>> GetUserApartmentBookings(int userId);

        Task<ICollection<RoomBooking>> GetRoomBookings(int roomId);

        Task<ICollection<RoomBooking>> GetUserRoomBookings(int userId);

        Task DeleteRoomBooking(int id, int userId);

        Task DeleteApartmentBooking(int id, int userId);
    }
}
