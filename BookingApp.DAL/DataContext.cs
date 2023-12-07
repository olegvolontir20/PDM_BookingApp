using BookingApp.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookingApp.DAL
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<ApartmentBooking> ApartmentBookings { get; set; }
        public DbSet<ApartmentReview> ApartmentReviews { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<HotelReview> HotelReviews { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomBooking> RoomBookings { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<FavoriteApartment>? FavoriteApartment { get; set; }
        public DbSet<FavoriteHotel>? FavoriteHotel { get; set; }

    }
}
