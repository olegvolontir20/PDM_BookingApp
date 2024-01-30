using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.DAL.DTO
{
    [Table("Hotel")]
    public class HotelDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? Phone { get; set; }
        public string? Description { get; set; }
        public ICollection<RoomDTO>? Rooms { get; set; }
        public ICollection<RoomBookingDTO>? RoomBookings { get; set; }
        public string? PathImage { get; set; }

        public ICollection<HotelReviewDTO>? Reviews { get; set; }

    }
}
