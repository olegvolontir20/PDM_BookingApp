using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookingApplication.DAL;
using BookingApplication.Entities.ServiceResult;
using BookingApplication.Entities.Models;
using BookingApplication.Entities;
using System.Linq;
using NuGet.Protocol.Core.Types;

namespace BookingApplication.Services
{
    public class HotelsService : IHotelsService
    {
        private readonly IHotelsRepository _repository;

        public HotelsService(IHotelsRepository repository)
        {
            _repository = repository;
        }


        public async Task<HotelList> GetHotels()
        {
            var hotelData = await _repository.GetHotels();

            var res = new HotelList();

            res.Hotels = hotelData;

            res.count = hotelData.Count;

            return res;
        }

        public async Task<Hotel> GetHotelById(int id)
        {
            var hotelData = await _repository.GetHotelById(id);

            var res = new Hotel();

            res = hotelData;

            return res;
        }

        public async Task<HotelList> SearchFilterAndSortHotels(BookModel bookModel)
        {
            List<Hotel> hotels = new();
            try
            {
                var hotelData = await _repository.GetHotels();
                var availableHotels = new List<Hotel>();

                foreach (var hotel in hotels)
                {
                    var hotelbookings = await _repository.GetHotelBookings();
                    bool isbooked = false;

                    foreach (var hotelbooking in hotelbookings)
                    {
                        if (hotelbooking.Id == hotel.Id)
                        {
                            if (bookModel.StartDate <= hotelbooking.LastDay.Date && bookModel.EndDate >= hotelbooking.FirstDay.Date)
                            {
                                isbooked = true;
                                break;
                            }
                        }
                    }

                    if (!isbooked)
                    {
                        availableHotels.Add(hotel);
                    }


                }

                availableHotels = availableHotels.OrderBy(a => a.Name).ToList();

                // Assuming AppartmentList has a property named Apartaments
                var result = new HotelList { Hotels = availableHotels };

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

    }
}
