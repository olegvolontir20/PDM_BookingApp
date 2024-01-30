using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Domain.Models.ApiRequests
{
    public class AddRoomBookingModel
    {
        public int Room_Id { get; set; }
        public DateTime FirstDay { get; set; }
        public DateTime LastDay { get; set; }
        public int NumberOfPeople { get; set; }
    }
}
