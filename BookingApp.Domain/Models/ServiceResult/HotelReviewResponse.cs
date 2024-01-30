using BookingApp.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Domain.Models.ServiceResult
{
    public class HotelReviewResponse
    {
        public int Id { get; set; }
        public int User_Id { get; set; }
        public string? Body { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        public User? User { get; set; }
    }
}
