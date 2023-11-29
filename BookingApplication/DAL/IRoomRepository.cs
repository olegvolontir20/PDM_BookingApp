using BookingApplication.Entities.Models;

namespace BookingApplication.DAL
{
    public interface IRoomRepository
    {

        Task<List<Room>> GetRooms();
    }
}
