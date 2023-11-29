using BookingApplication.DAL;
using BookingApplication.Entities.Models;

namespace BookingApplication.Entities.ServiceResult
{
    public class AppartmentList
    {
        public int count { get; set; }

        public List<Apartament> Apartaments { get; set; }
    }
}
