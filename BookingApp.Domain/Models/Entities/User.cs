using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookingApp.Domain.Models.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string? Name { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }

        public List<HotelReview>? HotelReviews { get; set; }
        public List<ApartmentReview>? ApartmentReviews { get; set; }

        public List<FavoriteHotel>? FavoriteHotels { get; set; }
        public List<FavoriteApartment>? FavoriteApartments { get; set; }

    }
}
