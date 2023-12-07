using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Domain.Models.Entities
{
    public class FavoriteApartment
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User? User { get; set; }
        //migr
        public int ApartmentId { get; set; }
        public Apartment? Apartment { get; set; }
    }
}
