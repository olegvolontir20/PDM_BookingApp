using BookingApp.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Domain.Models.ServiceResult
{
    public class ApartmentBookingResponse
    {
        public int Id { get; set; }
        public int User_Id { get; set; }
        public int Ap_Id { get; set; }
        public DateTime FirstDay { get; set; }
        public DateTime LastDay { get; set; }
        public int NumberOfPeople { get; set; }
        public ApartmentResponse? Apartment { get; set; }
    }
}
