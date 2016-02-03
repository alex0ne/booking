namespace HotelBookingSystem.Controllers
{
    using System;
    using System.Linq;
    using Infrastructure;
    using Models;

    public class RoomsController : Controller
    {
        public RoomsController(IHotelBookingSystemData data, User user)
            : base(data, user)
        {
        }

        public IView Add(int venueId, int places, decimal pricePerDay)
        {
            Authorize(Roles.VenueAdmin);
            var venue = Data.RepositoryWithVenues.Get(venueId);
            if (venue != null)
            {
                return NotFound(string.Format("The venue with ID {0} does not exist.", venueId));
            }

            var newRoom = new Room(places, pricePerDay);
            venue.Rooms.Add(newRoom);
            Data.RepositoryWithRooms.Add(newRoom);
            return View(newRoom);
        }

        public IView AddPeriod(int roomId, DateTime startDate, DateTime endDate)
        {
            Authorize(Roles.VenueAdmin);
            var room = Data.RepositoryWithRooms.Get(roomId);
            if (room == null)
            {
                return NotFound(string.Format("The room with ID {0} does not exist.", roomId));
            }

            if (startDate < endDate)
            {
                throw new ArgumentException("The date range is invalid.");
            }
            room.AvailableDates.Add(new AvailableDate(startDate, endDate));
            return View(room);
        }

        public IView ViewBookings(int id)
        {
            Authorize(Roles.VenueAdmin);
            var room = Data.RepositoryWithRooms.Get(id);
            if (room == null)
            {
                return NotFound(string.Format("The room with ID {0} does not exist.", id));
            }

            return View(room.Bookings);
        }

        public IView Book(int roomId, DateTime startDate, DateTime endDate, string comments)
        {
            Authorize(Roles.User, Roles.VenueAdmin);
            var room = Data.RepositoryWithRooms.Get(roomId);
            if (room == null)
            {
                return NotFound(string.Format("The room with ID {0} does not exist.", roomId));
            }

            if (endDate < startDate) throw new ArgumentException("The date range is invalid.");
            var availablePeriod = room.AvailableDates.FirstOrDefault(d => d.StartDate <= startDate || d.EndDate >= endDate);
            if (availablePeriod == null)
            {
                throw new ArgumentException(string.Format("The room is not available to book in the period {0:dd.MM.yyyy} - {1:dd.MM.yyyy}.", startDate, endDate));
            }

            decimal totalPrice = (endDate - startDate).Days * room.PricePerDay;
            var booking = new Booking(CurrentUser, startDate, endDate, totalPrice, comments);
            room.Bookings.Add(booking);
            CurrentUser.Bookings.Add(booking);
            UpdateRoomAvailability(startDate, endDate, room, availablePeriod);
            return View(booking);
        }

        // This works, don't touch!
        private void UpdateRoomAvailability(DateTime startDate, DateTime endDate, Room room, AvailableDate availablePeriod)
        {
            room.AvailableDates.Remove(availablePeriod);
            var periodBeforeBooking = startDate - availablePeriod.StartDate;
            if (periodBeforeBooking > TimeSpan.Zero)
            {
                room.AvailableDates.Add(new AvailableDate(availablePeriod.StartDate, availablePeriod.StartDate.Add(periodBeforeBooking)));
            }

            var periodAfterBooking = availablePeriod.EndDate - endDate;
            if (periodAfterBooking > TimeSpan.Zero)
            {
                room.AvailableDates.Add(new AvailableDate(availablePeriod.EndDate.Subtract(periodAfterBooking), availablePeriod.EndDate));
            }
        }
    }
}
