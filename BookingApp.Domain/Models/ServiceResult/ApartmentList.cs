using BookingApp.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Domain.Models.ServiceResult
{
    public class ApartmentList
    {
        public int Count { get; set; }

        public List<Apartment>? Apartments { get; set; }
    }
}
