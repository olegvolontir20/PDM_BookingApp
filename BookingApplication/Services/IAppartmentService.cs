using BookingApplication.Entities;
using BookingApplication.Entities.Models;
using BookingApplication.Entities.ServiceResult;

namespace BookingApplication.Services
{
    public interface IAppartmentService
    {
        Task<AppartmentList> GetApartaments();

        Task<Apartament> GetApartament(int id);

        Task<AppartmentList> SearchFilterAndSortApartaments(BookModel bookModel);
    }
}
