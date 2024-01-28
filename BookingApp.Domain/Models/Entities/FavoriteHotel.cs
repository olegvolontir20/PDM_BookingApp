using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Domain.Models.Entities
{
    public class FavoriteHotel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public int HotelId { get; set; }
        public Hotel? Hotel { get; set; }
    }
}
