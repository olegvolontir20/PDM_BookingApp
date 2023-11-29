using BookingApplication.Entities;
using BookingApplication.Entities.Models;

namespace BookingApplication.DAL
{
    public interface IHotelsRepository
    {

        Task<List<Hotel>> GetHotels();

        Task<Hotel> GetHotelById(int id);

        Task<List<Hotel>> SearchFilterAndSortHotels(BookModel bookModel);

        Task<List<RoomBooking>> GetHotelBookings();
    }
}
