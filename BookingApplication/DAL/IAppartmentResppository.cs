using BookingApplication.Entities;
using BookingApplication.Entities.Models;

namespace BookingApplication.DAL
{
    public interface IAppartmentResppository
    {
        Task<List<Apartament>> GetApartaments();

        Task<Apartament> GetApartamentById(int id);

        Task<List<Apartament>> SearchFilterAndSortApartaments(BookModel bookModel);

        Task<List<ApartamentBooking>> GetApartamentBookings();
    }
}
