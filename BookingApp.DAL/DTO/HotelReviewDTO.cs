﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.DAL.DTO
{
    [Table("HotelReview")]
    public class HotelReviewDTO
    {
        public int Id { get; set; }

        public int User_Id { get; set; }
        public int Hotel_Id { get; set; }
        public string? Body { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }

        [ForeignKey("User_Id")]
        public UserDTO? User { get; set; }
        [ForeignKey("Hotel_Id")]
        public HotelDTO? Hotel { get; set; }
    }
}
