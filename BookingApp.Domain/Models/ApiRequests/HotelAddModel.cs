using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Domain.Models.ApiRequests
{
    public class HotelAddModel
    {
        public string? Name { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? Phone { get; set; }
        public string? Description { get; set; }
        public List<AddRoomModel>? Rooms { get; set; }
        //public List<RoomBooking>? RoomBookings { get; set; }
        public string? PathImage { get; set; }

        //public List<HotelReview>? Reviews { get; set; }
    }
}
