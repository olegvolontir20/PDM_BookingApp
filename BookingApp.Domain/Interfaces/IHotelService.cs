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
        Task<IEnumerable<HotelResponse>> GetHotels();

        Task<IEnumerable<HotelResponse>> SearchFilterAndSortHotels(SearchBookingModel bookModel);

        Task<IEnumerable<HotelResponse>> GetLastThreeLocations();

        Task<HotelResponse> GetHotel(int id);

        Task PutHotel(int id, Hotel hotel);

        Task<Hotel> PostHotel(HotelAddModel hotel);

        Task DeleteHotel(int id);
    }
}
