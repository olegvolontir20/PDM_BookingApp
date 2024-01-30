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
        Task<ICollection<Hotel>> GetHotels();

        Task<ICollection<Room>> GetRooms(int hotelId);

        Task<Room> GetRoom(int roomId);

        Task<ICollection<Hotel>> SearchFilterAndSortHotels(SearchBookingModel bookModel);

        Task<ICollection<Hotel>> GetLastThreeLocations();

        Task<Hotel> GetHotel(int id);

        Task PutHotel(Hotel hotel);

        Task<Hotel> PostHotel(Hotel hotel);

        Task DeleteHotel(int id);
    }
}
