namespace HotelBookingSystem.Data
{
    using Interfaces;
    using Models;

    public class HotelBookingSystemData : IHotelBookingSystemData
    {
        public HotelBookingSystemData()
        {
            this.RepositoryWithUsers = new UserRepository();
            this.RepositoryWithVenues = new Repository<Venue>();
            this.RepositoryWithRooms = new Repository<Room>();
            this.RepositoryWithBookings = new Repository<Booking>();
        }

        public IUserRepository RepositoryWithUsers { get; private set; }

        public IRepository<Venue> RepositoryWithVenues { get; private set; }

        public IRepository<Room> RepositoryWithRooms { get; private set; }

        public IRepository<Booking> RepositoryWithBookings { get; private set; }
    }
}
