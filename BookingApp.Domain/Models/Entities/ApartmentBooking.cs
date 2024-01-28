﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Domain.Models.Entities
{
    public class ApartmentBooking
    {
        public int Id { get; set; }
        public int User_Id { get; set; }
        public int Ap_Id { get; set; }
        public DateTime FirstDay { get; set; }
        public DateTime LastDay { get; set; }
        public int NumberOfPeople { get; set; }
        public User? User { get; set; }
        public Apartment? Apartment { get; set; }
    }
}
