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
    public interface IApartmentService
    {
        Task<IEnumerable<ApartmentResponse>> GetApartments();

        Task<ApartmentResponse> GetApartment(int id);

        Task<IEnumerable<ApartmentResponse>> SearchFilterAndSortApartments(SearchBookingModel bookModel);

        Task<IEnumerable<ApartmentResponse>> GetLastThreeLocations();

        Task PutApartment(int id, Apartment apartment);

        Task<Apartment> PostApartment(ApartmentAddModel apartment);

        Task DeleteApartment(int id);
    }
}
