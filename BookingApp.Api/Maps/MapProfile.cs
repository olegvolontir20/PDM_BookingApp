using System;
using BookingApp.Domain.Models.Entities;
using BookingApp.Domain.Models.ServiceResult;
using BookingApp.Domain.Models.ApiRequests;
using BookingApp.DAL.DTO;
using AutoMapper;

namespace BookingApp.Api.MapProfiles
{
    public class MapProfile : Profile
    {
        public MapProfile() 
        {
            CreateMap<Apartment, ApartmentResponse>();
            CreateMap<ApartmentAddModel, Apartment>();

            CreateMap<HotelAddModel, Hotel>();
            CreateMap<Hotel, HotelResponse>();

            CreateMap<UserSignUpModel, UserDTO>();

            CreateMap<ApartmentDTO, Apartment>();
            CreateMap<Apartment, ApartmentDTO>();

            CreateMap<ApartmentBookingDTO, ApartmentBooking>();
            CreateMap<ApartmentReviewDTO, ApartmentReview>();
            CreateMap<FavoriteApartmentDTO, FavoriteApartment>();
            CreateMap<FavoriteHotelDTO, FavoriteHotel>();

            CreateMap<HotelDTO, Hotel>();
            CreateMap<Hotel, HotelDTO>();

            CreateMap<HotelReviewDTO, HotelReview>();
            CreateMap<RoomBookingDTO, RoomBooking>();
            CreateMap<RoomDTO, Room>();

            CreateMap<UserDTO, User>();
            CreateMap<User, UserDTO>();
        }
    }
}
