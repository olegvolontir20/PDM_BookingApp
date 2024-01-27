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
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository _repository;
        private readonly IMapper _mapper;

        public HotelService(IHotelRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<HotelResponse> GetHotel(int id)
        {
            var hotelData = await _repository.GetHotel(id);

            return _mapper.Map<Hotel, HotelResponse>(hotelData);
        }

        public async Task<IEnumerable<HotelResponse>> GetHotels()
        {
            var hotelData = await _repository.GetHotels();

            return _mapper.Map<IEnumerable<Hotel>, IEnumerable<HotelResponse>>(hotelData);
        }

        public async Task<IEnumerable<HotelResponse>> GetLastThreeLocations()
        {
            var lastThreeHotels = await _repository.GetLastThreeLocations();

            return _mapper.Map<IEnumerable<Hotel>, IEnumerable<HotelResponse>>(lastThreeHotels);
        }

        public async Task<IEnumerable<HotelResponse>> SearchFilterAndSortHotels(BookingModel bookModel)
        {
            try
            {
                var hotels = await _repository.SearchFilterAndSortHotels(bookModel);
                foreach (var hotel in hotels)
                {
                    List<Room> rooms = hotel.Rooms;
                    List<Room> availableRooms = new();

                    foreach (var room in rooms)
                    {
                        var roomBookings = await _repository.GetRoomBookings();
                        bool isBooked = false;
                        foreach (var roomBooking in roomBookings)
                        {
                            if (roomBooking.Room_Id == room.Id)
                            {
                                if (bookModel.StartDate <= roomBooking.LastDay.Date && bookModel.EndDate >= roomBooking.FirstDay.Date)
                                {
                                    isBooked = true;
                                    break;
                                }
                            }
                        }
                        if (!isBooked)
                        {
                            availableRooms.Add(room);
                        }
                    }
                    hotel.Rooms = availableRooms;
                }

                hotels = hotels.Where(h => h.Rooms.Count() > 0).ToList();
                hotels = hotels.OrderBy(h => h.Name).ToList();//sortare dupa nume hotel crescator

                return _mapper.Map<IEnumerable<Hotel>, IEnumerable<HotelResponse>>(hotels);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task PutHotel(int id, Hotel hotel)
        {
            await _repository.PutHotel(hotel);
        }

        public async Task<Hotel> PostHotel(HotelAddModel hotel)
        {
            var res = await _repository.PostHotel(_mapper.Map<HotelAddModel, Hotel>(hotel));

            if (res == null)
            {
                throw new Exception("Post Failed");
            }

            return res;
        }

        public async Task DeleteHotel(int id)
        {
            try
            {
                await _repository.DeleteHotel(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
