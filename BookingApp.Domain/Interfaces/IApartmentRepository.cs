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
        Task<List<Apartment>> GetApartments();

        Task<Apartment> GetApartmentById(int id);

        //Task<List<Apartment>> SearchFilterAndSortApartments(BookingModel bookModel);

        Task<List<ApartmentBooking>> GetApartmentBookings();

        Task<List<Apartment>> GetLastThreeLocations();

        Task PutApartment(int id, Apartment apartment);

        Task<Apartment> PostApartment(Apartment apartment);

        Task DeleteApartment(int id);
    }
}
