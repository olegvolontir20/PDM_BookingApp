using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingApplication.Entities.Models
{
    [Table("Apartaments")]
    public class Apartament
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public int Capacity { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public List<ApartamentBooking>? ApartamentBookings { get; set; }
        public List<ApartamentReview>? Reviews { get; set; }
        public string PathImage { get; set; }

    }
}
