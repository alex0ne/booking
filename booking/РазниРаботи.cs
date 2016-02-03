using HotelBookingSystem.Models;
using System.Collections.Generic;

public interface IDbEntity
{
    int Id { get; set; }
}
public interface IEndpoint
{
    string ControllerName { get; }
    string ActionName { get; }
    IDictionary<string, string> Parameters { get; }
}
public interface IEngine
{
    void StartOperation();
}
public interface IView
{
    object Model { get; }
    string Display();
}
public interface IRepository<T>
{
    IEnumerable<T> GetAll();
    T Get(int id);
    void Add(T item);
    bool Update(int id, T newItem);
    bool Delete(int id);
}
public interface IUserRepository : IRepository<User>
{
    User GetByUsername(string username);
}
public interface IHotelBookingSystemData
{
    IUserRepository RepositoryWithUsers { get; }
    IRepository<Venue> RepositoryWithVenues { get; }
    IRepository<Room> RepositoryWithRooms { get; }
    IRepository<Booking> RepositoryWithBookings { get; }
}

// Ever wondered about the difference between I...able and I...er? Here it is :)
interface IF_ckable
{
    void GetF_cked();
}
interface IF_cker
{
    void F_ck(IF_ckable target);
}