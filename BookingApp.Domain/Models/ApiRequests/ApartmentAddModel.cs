using BookingApp.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Domain.Models.ApiRequests
{
    public class ApartmentAddModel
    {
        public string? Name { get; set; }

        public string? City { get; set; }

        public string? Country { get; set; }

        public string? Phone { get; set; }

        public int Capacity { get; set; }

        public int Price { get; set; }

        public string? Description { get; set; }

        public string? PathImage { get; set; }
    }
}
