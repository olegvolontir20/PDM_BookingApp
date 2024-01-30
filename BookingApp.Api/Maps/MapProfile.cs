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
            //Request models and etc
            CreateMap<Apartment, ApartmentResponse>();
            CreateMap<ApartmentAddModel, Apartment>();

            CreateMap<HotelAddModel, Hotel>();
            CreateMap<Hotel, HotelResponse>();

            CreateMap<UserSignUpModel, UserDTO>();

            CreateMap<AddApartmentBookingModel, ApartmentBooking>();

            CreateMap<AddRoomBookingModel, RoomBooking>();

            CreateMap<AddRoomModel, Room>();

            CreateMap<Room, RoomResponse>();

            CreateMap<HotelReview, HotelReviewResponse>();

            CreateMap<ApartmentReview, ApartmentReviewResponse>();

            //Database DTO
            CreateMap<ApartmentDTO, Apartment>();
            CreateMap<Apartment, ApartmentDTO>();

            CreateMap<ApartmentBookingDTO, ApartmentBooking>();
            CreateMap<ApartmentBooking, ApartmentBookingDTO>();

            CreateMap<ApartmentReviewDTO, ApartmentReview>();
            CreateMap<ApartmentReview, ApartmentReviewDTO>();

            CreateMap<FavoriteApartmentDTO, FavoriteApartment>();
            CreateMap<FavoriteApartment, FavoriteApartmentDTO>();

            CreateMap<FavoriteHotelDTO, FavoriteHotel>();
            CreateMap<FavoriteHotel, FavoriteHotelDTO>();

            CreateMap<HotelDTO, Hotel>();
            CreateMap<Hotel, HotelDTO>();

            CreateMap<HotelReviewDTO, HotelReview>();
            CreateMap<HotelReview, HotelReviewDTO>();

            CreateMap<RoomBookingDTO, RoomBooking>();
            CreateMap<RoomBooking, RoomBookingDTO>();

            CreateMap<RoomDTO, Room>();
            CreateMap<Room, RoomDTO>();

            CreateMap<UserDTO, User>();
            CreateMap<User, UserDTO>();
        }
    }
}
