using BookingApp.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Domain.Models.ServiceResult
{
    public class ApartmentResponseList
    {
        public int Count { get; set; }

        public List<ApartmentResponse>? Apartments { get; set; }
    }
}
