using BookingApp.Domain.Models.ApiRequests;
using BookingApp.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Domain.Interfaces
{
    public interface IApartmentRepository
    {
        Task<IEnumerable<Apartment>> GetApartments();

        Task<Apartment> GetApartmentById(int id);

        Task<IEnumerable<Apartment>> SearchFilterAndSortApartments(SearchBookingModel bookModel);

        Task<IEnumerable<ApartmentBooking>> GetApartmentBookings();

        Task<IEnumerable<Apartment>> GetLastThreeLocations();

        Task PutApartment(Apartment apartment);

        Task<Apartment> PostApartment(Apartment apartment);

        Task DeleteApartment(int id);
    }
}
