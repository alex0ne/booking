namespace HotelBookingSystem.Models
{
    using System;
    using System.Collections.Generic;
    using Interfaces;
    using Utilities;

    public class User : IDbEntity
    {
        private string username;
        private string password;

        public User(string username, string password, Roles role)
        {
            this.Username = username;
            this.Password = password;
            this.Role = role;
            this.Bookings = new List<Booking>();
        }

        public int Id { get; set; }

        public string Username
        {
            get
            {
                return this.username;
            }

            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException("The username must be at least 5 symbols long.");
                }

                this.username = value;
            }
        }

        public string Password
        {
            get
            {
                return this.password;
            }

            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 6)
                {
                    throw new ArgumentException("The password must be at least 6 symbols long.");
                }

                this.password = HashUtilities.GetSha256Hash(value);
            }
        }

        public Roles Role { get; private set; }

        public ICollection<Booking> Bookings { get; private set; }
    }
}
