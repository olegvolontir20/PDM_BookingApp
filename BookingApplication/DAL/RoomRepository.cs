using BookingApplication.Entities.Models;

namespace BookingApplication.DAL
{
    public class RoomRepository : IRoomRepository
    {
        private readonly DataContext _context;


        public RoomRepository(DataContext context)
        {
            _context = context;
        }

        public Task<List<Room>> GetRooms()
        {
            throw new NotImplementedException();
        }
    }
}
