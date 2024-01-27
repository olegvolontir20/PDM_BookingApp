using System;
using BookingApp.Domain.Models.Entities;
using BookingApp.Domain.Models.ServiceResult;
using BookingApp.Domain.Models.ApiRequests;
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
        }
    }
}
