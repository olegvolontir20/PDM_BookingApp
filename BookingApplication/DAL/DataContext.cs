using BookingApplication.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingApplication.DAL
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Apartament> Apartaments { get; set; }
        public DbSet<ApartamentBooking> ApartamentBookings { get; set;}
        public DbSet<ApartamentReview> ApartamentReviews { get; set;}
        public DbSet<Hotel> Hotels { get; set;} 
        public DbSet<HotelReview> HotelReviews { get; set;}
        public DbSet<Room> Rooms { get; set;}
        public DbSet<RoomBooking> RoomBookings { get; set;}
        public DbSet<User> Users { get; set;}
        public DbSet<BookingApplication.Entities.Models.FavoriteApartament>? FavoriteApartament { get; set; }
        public DbSet<BookingApplication.Entities.Models.FavoriteHotel>? FavoriteHotel { get; set; }

    }
}
