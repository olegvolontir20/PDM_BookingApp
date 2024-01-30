using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookingApp.Domain.Models.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public ICollection<HotelReview>? HotelReviews { get; set; }
        public ICollection<ApartmentReview>? ApartmentReviews { get; set; }
        public ICollection<FavoriteHotel>? FavoriteHotels { get; set; }
        public ICollection<FavoriteApartment>? FavoriteApartments { get; set; }
    }
}
