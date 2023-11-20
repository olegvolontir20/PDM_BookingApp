using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingApplication.Entities.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public List<HotelReview>? HotelReviews { get; set; }
        public List<ApartamentReview>? ApartamentReviews { get; set; }

        public List<FavoriteHotel>? FavoriteHotels { get; set; }
        public List<FavoriteApartament>? FavoriteApartaments { get; set; }

    }
}
