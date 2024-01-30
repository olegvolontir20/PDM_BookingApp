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
        Task<ICollection<Apartment>> GetApartments();

        Task<Apartment> GetApartmentById(int id);

        Task<ICollection<Apartment>> SearchFilterAndSortApartments(SearchBookingModel bookModel);

        Task<ICollection<Apartment>> GetLastThreeLocations();

        Task PutApartment(Apartment apartment);

        Task<Apartment> PostApartment(Apartment apartment);

        Task DeleteApartment(int id);
    }
}
