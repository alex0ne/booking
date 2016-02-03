namespace HotelBookingSystem.Views
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Infrastructure;
    using Models;

    public class ViewBookings : View
    {
        public ViewBookings(IEnumerable<Booking> bookings)
            : base(bookings)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            var bookings = this.Model as IEnumerable<Booking>;

            viewResult.AppendLine(!bookings.Any() ? "There are no bookings for this room." : "Room bookings:");

            foreach (var booking in bookings)
            {
                viewResult.AppendFormat("* {0:dd.MM.yyyy} - {1:dd.MM.yyyy} (${2:F2})", booking.StartBookDate, booking.EndBookDate, booking.TotalPrice).AppendLine();
            }

            viewResult.AppendFormat("Total booking price: ${0:F2}", bookings.Sum(b => b.TotalPrice)).AppendLine();
        }
    }
}
