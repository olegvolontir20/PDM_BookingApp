using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Domain.Models.ApiRequests
{
    public  class AddRoomModel
    {
        public int NumberOfRoom { get; set; }
        public int Capacity { get; set; }
        public int Price { get; set; }
    }
}
