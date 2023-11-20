using System.ComponentModel.DataAnnotations.Schema;

namespace BookingApplication.Entities.Models
{
    [Table("FavoriteHotels")]
    public class FavoriteHotel
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User? User { get; set; }

        public int HotelId { get; set; }
        public Hotel? Hotel { get; set; }
    }
}
