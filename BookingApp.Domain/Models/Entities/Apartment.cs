using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BookingApp.Domain.Models.Entities
{
    public sealed class Apartment
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string? Name { get; set; }
        [Required]
        [StringLength(50)]
        public string? City { get; set; }
        [Required]
        [StringLength(50)]
        public string? Country { get; set; }
        [Required]
        [StringLength(50)]
        public string? Phone { get; set; }
        [Required]
        public int Capacity { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        [StringLength(500)]
        public string? Description { get; set; }
        public List<ApartmentBooking>? ApartmentBookings { get; set; }
        public List<ApartmentReview>? Reviews { get; set; }
        public string? PathImage { get; set; }

    }
}
