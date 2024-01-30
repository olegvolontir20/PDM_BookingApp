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
        private readonly IBookingRepository _bookingRepository;
        private readonly IMapper _mapper;

        public ApartmentService(IApartmentRepository repository, IBookingRepository bookingRepository, IMapper mapper)
        {
            _repository = repository;
            _bookingRepository = bookingRepository;
            _mapper = mapper;
        }

        public async Task<ApartmentResponse> GetApartment(int id)
        {
            var apartmentData = await _repository.GetApartmentById(id);

            return _mapper.Map<Apartment,ApartmentResponse>(apartmentData);
        }

        public async Task<ICollection<ApartmentResponse>> GetApartments()
        {
            var apartmentData = await _repository.GetApartments();

            return _mapper.Map<ICollection<Apartment>, ICollection<ApartmentResponse>>(apartmentData);
        }

        public async Task<ICollection<ApartmentResponse>> SearchFilterAndSortApartments(SearchBookingModel bookModel)
        {
            try
            {
                var apartmentData = await _repository.SearchFilterAndSortApartments(bookModel);
                var availableApartments = new List<Apartment>();

                foreach (var apartment in apartmentData)
                {
                    var apartmentBookings = await _bookingRepository.GetApartmentBookings(apartment.Id);
                    bool isBooked = false;

                    foreach (var apartmentBooking in apartmentBookings)
                    {

                        if (bookModel.StartDate <= apartmentBooking.LastDay.Date && bookModel.EndDate >= apartmentBooking.FirstDay.Date)
                        {
                            isBooked = true;
                            break;
                        }
                    }

                    if (!isBooked)
                    {
                        availableApartments.Add(apartment);
                    }
                }

                availableApartments = availableApartments.OrderBy(a => a.Name).ToList();

                // Assuming ApartmentList has a property named Apartments
                var result = _mapper.Map<List<Apartment>, ICollection<ApartmentResponse>>(availableApartments);

                return result;
            }
            catch (Exception ex)
            {
                // Handle the exception appropriately (log, rethrow, etc.)
                throw ex;
            }
        }

        public async Task<ICollection<ApartmentResponse>> GetLastThreeLocations()
        {
            var lastThreeApartaments = await _repository.GetLastThreeLocations();

            return _mapper.Map<ICollection<Apartment>, ICollection<ApartmentResponse>>(lastThreeApartaments);
        }

        public async Task PutApartment(int id, Apartment apartament)
        {
            await _repository.PutApartment(apartament);
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
