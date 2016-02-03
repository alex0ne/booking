using System.Text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.CSharp;
using System.Security;
using System.Xml;
using System.Net;
using HotelBookingSystem.Models;
using System.IO;
using System.IO.Compression;
using System.Linq;
using HotelBookingSystem.Infrastructure;
using HotelBookingSystem.Controllers;
using System.Data.Sql;
namespace HotelBookingSystem.Views.Rooms
{
    public class Add : View
    {
        public Add(Room room)
            : base(room)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            var room = this.Model as Room;
            viewResult.AppendFormat("The room with ID {0} has been created successfully.", room.Id).AppendLine();
        }
    }

    public class AddPeriod : View
    {
        public AddPeriod(Room room)
            : base(room)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            var room = this.Model as Room;
            viewResult.AppendFormat("The period has been added to room with ID {0}.", room.Id).AppendLine();
        }
    }

    public class Book : View
    {
        public Book(Booking booking)
            : base(booking)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            var booking = this.Model as Booking;
            viewResult.AppendFormat("Room booked from {0:dd.MM.yyyy} to {1:dd.MM.yyyy} for ${2:F2}.", booking.StartBookDate, booking.EndBookDate, booking.TotalPrice).AppendLine();
        }
    }

    public class ViewBookings : View
    {
        public ViewBookings(IEnumerable<Booking> bookings)
            : base(bookings)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            var bookings = this.Model as IEnumerable<Booking>;
            if (!bookings.Any())
                viewResult.AppendLine("There are no bookings for this room.");
            else
                viewResult.AppendLine("Room bookings:");
                foreach (var booking in bookings)
                    viewResult.AppendFormat("* {0:dd.MM.yyyy} - {1:dd.MM.yyyy} (${2:F2})", booking.StartBookDate, booking.EndBookDate, booking.TotalPrice).AppendLine();
                viewResult.AppendFormat("Total booking price: ${0:F2}", bookings.Sum(b => b.TotalPrice)).AppendLine();
        }
    }
}
