using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingApplication.Entities.Models
{
    [Table("Hotels")]
    public class Hotel
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }
        public List<Room> Rooms { get; set; }
        public List<RoomBooking>? RoomBookings { get; set; }
        public string PathImage { get; set; }

        public List<HotelReview>? Reviews { get; set; }

    }
}
