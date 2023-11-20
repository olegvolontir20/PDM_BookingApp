using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingApplication.Entities.Models
{
    [Table("Rooms")]
    public class Room
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public int NumberOfRoom { get; set; }
        public int Capacity { get; set; }
        public int Price { get; set; }
        public int Hotel_Id { get; set; }

        [ForeignKey("Hotel_Id")]
        public Hotel? Hotel { get; set; }


    }
}
