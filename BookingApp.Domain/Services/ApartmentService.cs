using BookingApp.Domain.Interfaces;
using BookingApp.Domain.Models.ApiRequests;
using BookingApp.Domain.Models.Entities;
using BookingApp.Domain.Models.ServiceResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Domain.Services
{
    public class ApartmentService : IApartmentService
    {
        private readonly IApartmentRepository _repository;

        public ApartmentService(IApartmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<Apartment> GetApartment(int id)
        {
            var apartmentData = await _repository.GetApartmentById(id);

            var res = new Apartment();

            res = apartmentData;

            return res;
        }

        public async Task<ApartmentList> GetApartments()
        {
            var apartmentData = await _repository.GetApartments();

            var res = new ApartmentList();

            res.Apartments = apartmentData;

            res.Count = apartmentData.Count;

            return res;
        }

        public async Task<ApartmentList> SearchFilterAndSortApartments(BookingModel bookModel)
        {
            List<Apartment> apartments = new();
            try
            {
                var apartmentData = await _repository.GetApartments();
                var availableApartments = new List<Apartment>();

                foreach (var apartment in apartments)
                {
                    var apartmentBookings = await _repository.GetApartmentBookings();
                    bool isBooked = false;

                    foreach (var apartmentBooking in apartmentBookings)
                    {
                        if (apartmentBooking.Id == apartment.Id)
                        {
                            if (bookModel.StartDate <= apartmentBooking.LastDay.Date && bookModel.EndDate >= apartmentBooking.FirstDay.Date)
                            {
                                isBooked = true;
                                break;
                            }
                        }
                    }

                    if (!isBooked)
                    {
                        availableApartments.Add(apartment);
                    }
                }

                availableApartments = availableApartments.OrderBy(a => a.Name).ToList();

                // Assuming ApartmentList has a property named Apartments
                var result = new ApartmentList { Apartments = availableApartments };

                return result;
            }
            catch (Exception ex)
            {
                // Handle the exception appropriately (log, rethrow, etc.)
                throw ex;
            }
        }
    }
}
