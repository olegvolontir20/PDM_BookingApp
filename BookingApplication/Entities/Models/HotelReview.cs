using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingApplication.Entities.Models
{
    [Table("HotelReviews")]
    public class HotelReview
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public int User_Id { get; set; }
        public int Hotel_Id { get; set; }
        public string Body { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }

        [ForeignKey("User_Id")]
        public User? User { get; set; }
        [ForeignKey("Hotel_Id")]
        public Hotel? Hotel { get; set; }
    }
}
