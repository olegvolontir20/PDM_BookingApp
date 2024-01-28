using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.DAL.DTO
{
    [Table("FavoriteHotel")]
    public class FavoriteHotelDTO
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public UserDTO? User { get; set; }

        public int HotelId { get; set; }
        public HotelDTO? Hotel { get; set; }
    }
}
