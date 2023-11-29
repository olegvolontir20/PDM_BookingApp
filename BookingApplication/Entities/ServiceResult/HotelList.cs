using BookingApplication.Entities.Models;

namespace BookingApplication.Entities.ServiceResult
{
    public class HotelList
    {
        public int count { get; set; }

        public List<Hotel> Hotels { get; set; }
    }
}
