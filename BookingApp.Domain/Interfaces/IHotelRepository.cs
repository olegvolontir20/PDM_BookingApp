using BookingApp.Domain.Models.ApiRequests;
using BookingApp.Domain.Models.Entities;
using BookingApp.Domain.Models.ServiceResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Domain.Interfaces
{
    public interface IHotelRepository
    {
        Task<IEnumerable<Hotel>> GetHotels();

        Task<IEnumerable<Hotel>> SearchFilterAndSortHotels(BookingModel bookModel);

        Task<IEnumerable<Hotel>> GetLastThreeLocations();

        Task<IEnumerable<RoomBooking>> GetRoomBookings();

        Task<Hotel> GetHotel(int id);

        Task PutHotel(Hotel hotel);

        Task<Hotel> PostHotel(Hotel hotel);

        Task DeleteHotel(int id);
    }
}
