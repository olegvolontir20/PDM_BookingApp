using BookingApp.Domain.Models.ApiRequests;
using BookingApp.Domain.Models.ApiResponses;
using BookingApp.Domain.Models.Entities;
using BookingApp.Domain.Models.ServiceResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Domain.Interfaces
{
    public interface IHotelService
    {
        Task<ICollection<HotelResponse>> GetHotels();

        Task<ICollection<HotelResponse>> SearchFilterAndSortHotels(SearchBookingModel bookModel);

        Task<ICollection<HotelResponse>> GetLastThreeLocations();

        Task<HotelResponse> GetHotel(int id);

        Task<RoomResponse> GetRoom(int roomId);

        Task PutHotel(int id, Hotel hotel);

        Task<Hotel> PostHotel(HotelAddModel hotel);

        Task DeleteHotel(int id);
    }
}
