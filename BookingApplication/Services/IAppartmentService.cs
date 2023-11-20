using BookingApplication.Entities.ServiceResult;

namespace BookingApplication.Services
{
    public interface IAppartmentService
    {
        Task<AppartmentList> GetApartaments();
    }
}
