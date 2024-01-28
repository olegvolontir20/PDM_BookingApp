using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.DAL.DTO
{
    [Table("ApartmentBooking")]
    public class ApartmentBookingDTO
    {
        public int Id { get; set; }
        [Required]
        public int User_Id { get; set; }
        [Required]
        public int Ap_Id { get; set; }
        public DateTime FirstDay { get; set; }
        public DateTime LastDay { get; set; }
        public int NumberOfPeople { get; set; }

        [ForeignKey("User_Id")]
        public UserDTO? User { get; set; }
        [ForeignKey("Ap_Id")]
        public ApartmentDTO? Apartment { get; set; }
    }
}
