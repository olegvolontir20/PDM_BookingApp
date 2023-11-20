using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingApplication.Entities.Models
{
    [Table("ApartamentReviews")]
    public class ApartamentReview
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public int User_Id { get; set; }
        public int Apartament_Id { get; set; }
        public string Body { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }

        [ForeignKey("User_Id")]
        public User? User { get; set; }
        [ForeignKey("Apartament_Id")]
        public Apartament? Apartament { get; set; }
    }
}
