using System.ComponentModel.DataAnnotations.Schema;

namespace BookingApplication.Entities.Models
{
    [Table("FavoriteApartaments")]
    public class FavoriteApartament
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User? User { get; set; }
        //migr
        public int ApartamentId { get; set; }
        public Apartament? Apartament { get; set; }
    }
}
