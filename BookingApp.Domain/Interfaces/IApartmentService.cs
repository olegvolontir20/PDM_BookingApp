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
        Task<ApartmentList> GetApartments();

        Task<Apartment> GetApartment(int id);

        Task<ApartmentList> SearchFilterAndSortApartments(BookingModel bookModel);
    }
}
