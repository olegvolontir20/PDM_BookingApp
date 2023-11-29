using BookingApplication.Entities;
using BookingApplication.Entities.Models;
using BookingApplication.Entities.ServiceResult;

namespace BookingApplication.Services
{
    public interface IHotelsService
    {

        Task<HotelList> GetHotels();

        Task<Hotel> GetHotelById(int id);

        Task<HotelList> SearchFilterAndSortHotels(BookModel bookModel);
    }
}
