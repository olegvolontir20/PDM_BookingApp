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
    }
}
