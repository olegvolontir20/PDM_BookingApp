using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BookingApp.Domain.Models.Entities
{
    public sealed class Apartment
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? Phone { get; set; }
        public int Capacity { get; set; }
        public int Price { get; set; }
        public string? Description { get; set; }
        public ICollection<ApartmentBooking>? ApartmentBookings { get; set; }
        public ICollection<ApartmentReview>? Reviews { get; set; }
        public string? PathImage { get; set; }

    }
}
