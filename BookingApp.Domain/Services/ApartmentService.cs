using AutoMapper;
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
        private readonly IMapper _mapper;

        public ApartmentService(IApartmentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Apartment> GetApartment(int id)
        {
            var apartmentData = await _repository.GetApartmentById(id);

            return apartmentData;
        }

        public async Task<ApartmentResponseList> GetApartments()
        {
            var apartmentData = await _repository.GetApartments();

            var res = new ApartmentResponseList();

            res.Apartments = _mapper.Map<List<Apartment>?, List<ApartmentResponse>?>(apartmentData);

            res.Count = apartmentData.Count;

            return res;
        }

        public async Task<ApartmentResponseList> SearchFilterAndSortApartments(BookingModel bookModel)
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
                var result = new ApartmentResponseList { Apartments = _mapper.Map<List<ApartmentResponse>>(availableApartments)};

                return result;
            }
            catch (Exception ex)
            {
                // Handle the exception appropriately (log, rethrow, etc.)
                throw ex;
            }
        }

        public async Task<List<Apartment>> GetLastThreeLocations()
        {
            var lastThreeApartaments = await _repository.GetLastThreeLocations();

            return lastThreeApartaments;
        }

        public async Task PutApartment(int id, Apartment apartament)
        {
            await _repository.PutApartment(id, apartament);
        }

        public async Task<Apartment> PostApartment(ApartmentAddModel apartment)
        {

            var res = await _repository.PostApartment(_mapper.Map<ApartmentAddModel,Apartment>(apartment));

            if(res == null) 
            {
                throw new Exception("Post Failed");
            }

            return res;
        }

        public async Task DeleteApartment(int id)
        {
            try
            {
                await _repository.DeleteApartment(id);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
