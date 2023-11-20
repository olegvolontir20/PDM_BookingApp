using BookingApplication.Entities.Models;

namespace BookingApplication.DAL
{
    public interface IAppartmentResppository
    {
        Task<List<Apartament>> GetApartaments();
    }
}
