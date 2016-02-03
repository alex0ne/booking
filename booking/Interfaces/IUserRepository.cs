namespace HotelBookingSystem.Interfaces
{
    using HotelBookingSystem.Models;

    public interface IUserRepository : IRepository<User>
    {
        User GetByUsername(string username);
    }
}