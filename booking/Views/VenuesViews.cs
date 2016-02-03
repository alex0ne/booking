using HotelBookingSystem.Infrastructure;
using HotelBookingSystem.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelBookingSystem.Views.Venues
{
    public class All : View
    {
        public All(IEnumerable<Venue> venues)
            : base(venues)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            var venues = this.Model as IEnumerable<Venue>;
            if (!venues.Any())
            {
                viewResult.AppendLine("There are currently no venues to show.");
            }
            else
            {
                foreach (var venue in venues)
                {
                    viewResult.AppendFormat("*[{0}] {1}, located at {2}", venue.Id, venue.Name, venue.Address).AppendLine()
                        .AppendFormat("Free rooms: {0}", venue.Rooms.Count).AppendLine();
                }
            }
        }
    }

    public class Details : View
    {
        public Details(Venue venue)
            : base(venue)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            var venue = this.Model as Venue;
            viewResult.AppendLine(venue.Name)
                .AppendFormat("Located at {0}", venue.Address).AppendLine()
                .AppendFormat("Description: {0}", venue.Description).AppendLine();
            if (!venue.Rooms.Any())
            {
                viewResult.AppendFormat("No rooms are currently available");
            }
            else
            {
                viewResult.AppendLine("Available rooms:");
                foreach (var room in venue.Rooms)
                {
                    viewResult.AppendFormat(" * {0} places (${1:F2} per day)", room.Places, room.PricePerDay).AppendLine();
                }
            }
        }
    }

    public class Rooms : View
    {
        public Rooms(Venue venue)
            : base(venue)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            var venue = this.Model as Venue;
            viewResult.AppendFormat("Available rooms for venue {0}:", venue.Name).AppendLine();
            if (!venue.Rooms.Any())
            {
                viewResult.AppendFormat("No rooms are currently available.");
            }
            else
            {
                foreach (var room in venue.Rooms)
                {
                    viewResult.AppendFormat(" *[0] {1} places, ${2:F2} per day", room.Id, room.Places, room.PricePerDay).AppendLine();
                    if (!room.AvailableDates.Any())
                    {
                        viewResult.AppendLine("This room is not currently available.");
                    }
                    else
                    {
                        viewResult.AppendLine("Available dates:");
                        foreach (var datePair in room.AvailableDates.OrderBy(datePair => datePair.EndDate))
                        {
                            viewResult.AppendFormat(" - {0:dd.MM.yyyy} - {1:dd.MM.yyyy}", datePair.EndDate, datePair.StartDate).AppendLine();
                        }
                    }
                }
            }
        }
    }

    public class Add : View
    {
        public Add(Venue venue)
            : base(venue)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            var venue = this.Model as Venue;
            viewResult.AppendFormat("The venue {0} with ID {1} has been created successfully.", venue.Name, venue.Id).AppendLine();
        }
    }
}