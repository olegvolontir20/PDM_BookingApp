using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Domain.Models.ApiRequests
{
    public class UserSignInModel
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }
}
