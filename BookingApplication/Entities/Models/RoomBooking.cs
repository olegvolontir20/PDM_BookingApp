using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingApplication.Entities.Models
{
    [Table("RoomBookings")]
    public class RoomBooking
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public int User_Id { get; set; }
        public int Room_Id { get; set; }
        public DateTime FirstDay { get; set; }
        public DateTime LastDay { get; set; }
        public int NumberOfPeople { get; set; }

        [ForeignKey("User_Id")]
        public User? User { get; set; }
        [ForeignKey("Room_Id")]
        public Room? Room { get; set; }

    }

}
