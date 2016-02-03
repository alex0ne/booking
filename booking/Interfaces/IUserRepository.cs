using HotelBookingSystem.Models;

namespace HotelBookingSystem.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByUsername(string username);
    }
}