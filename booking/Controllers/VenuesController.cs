namespace HotelBookingSystem.Controllers
{
    using System;
    using Infrastructure;
    using Interfaces;
    using Models;

    public class VenuesController : Controller
    {
        public VenuesController(IHotelBookingSystemData data, User user)
            : base(data, user)
        {
        }

        public IView All()
        {
            var venues = this.Data.RepositoryWithVenues.GetAll();
            return this.View(venues);
        }

        public IView Details(int venueId)
        {
            this.Authorize(Roles.User, Roles.VenueAdmin);
            var venue = this.Data.RepositoryWithVenues.Get(venueId);
            return venue == null ? this.NotFound($"The venue with ID {venueId} does not exist.") : this.View(venue);
        }

        public IView Rooms(int id)
        {
            // TODO: Implement me
            throw new NotImplementedException();
        }

        public IView Add(string name, string address, string description)
        {
            var newVenue = new Venue(name, address, description, CurrentUser);
            this.Data.RepositoryWithVenues.Add(newVenue);
            return this.View(newVenue);
        }
    }
}