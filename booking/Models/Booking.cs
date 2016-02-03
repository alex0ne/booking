namespace HotelBookingSystem.Models
{
    using System;
    using Interfaces;

    public class Booking : IDbEntity
    {
        private decimal totalPrice;
        private User currentUser;
        private DateTime startDate;
        private DateTime endDate;
        private string comments;

        public Booking(User client, DateTime startBookDate, DateTime endBookDate, decimal totalPrice, string comments, User client1)
        {
            if (this.EndBookDate < this.StartBookDate)
            {
                throw new ArgumentException("The date range is invalid.");
            }

            this.StartBookDate = startBookDate;
            this.EndBookDate = endBookDate;
            this.TotalPrice = totalPrice;
        }

        public Booking(User currentUser, DateTime startDate, DateTime endDate, decimal totalPrice, string comments)
        {
            this.currentUser = currentUser;
            this.startDate = startDate;
            this.endDate = endDate;
            this.totalPrice = totalPrice;
            this.comments = comments;
        }

        public int Id { get; set; }

        public DateTime StartBookDate { get; }

        public DateTime EndBookDate { get; }

        public decimal TotalPrice
        {
            get
            {
                return this.totalPrice;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The total price must not be less than 0.");
                }

                this.totalPrice = value;
            }
        }
    }
}