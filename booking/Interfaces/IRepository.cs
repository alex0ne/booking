using System.Collections.Generic;

namespace HotelBookingSystem.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();

        T Get(int id);

        void Add(T item);

        bool Update(int id, T newItem);

        bool Delete(int id);
    }
}