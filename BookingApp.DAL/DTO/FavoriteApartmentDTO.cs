using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.DAL.DTO
{
    [Table("FavoriteApartment")]
    public class FavoriteApartmentDTO
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public UserDTO? User { get; set; }
        //migr
        public int ApartmentId { get; set; }
        public ApartmentDTO? Apartment { get; set; }
    }
}
