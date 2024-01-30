using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Domain.Models.ApiRequests
{
    public class SearchBookingModel
    {
        public string? Country { get; set; }
        public string? City { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Capacity { get; set; }
    }
}
