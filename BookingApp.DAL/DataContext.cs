using BookingApp.DAL.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace BookingApp.DAL
{
    public class DataContext : IdentityDbContext<UserDTO, IdentityRole<int>, int>
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<ApartmentDTO> Apartments { get; set; }
        public DbSet<ApartmentBookingDTO> ApartmentBookings { get; set; }
        public DbSet<ApartmentReviewDTO> ApartmentReviews { get; set; }
        public DbSet<HotelDTO> Hotels { get; set; }
        public DbSet<HotelReviewDTO> HotelReviews { get; set; }
        public DbSet<RoomDTO> Rooms { get; set; }
        public DbSet<RoomBookingDTO> RoomBookings { get; set; }
        //public DbSet<User> Users { get; set; }
        public DbSet<FavoriteApartmentDTO>? FavoriteApartment { get; set; }
        public DbSet<FavoriteHotelDTO>? FavoriteHotel { get; set; }

    }
}
