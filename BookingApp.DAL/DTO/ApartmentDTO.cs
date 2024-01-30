using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BookingApp.DAL.DTO
{
    [Table("Apartment")]
    public sealed class ApartmentDTO
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
        public ICollection<ApartmentBookingDTO>? ApartmentBookings { get; set; }
        public ICollection<ApartmentReviewDTO>? Reviews { get; set; }
        public string? PathImage { get; set; }

    }
}
