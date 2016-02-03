using System.Collections.Generic;
using System;
using HotelBookingSystem.Utilities;

namespace HotelBookingSystem.Models
{

    public class User : IDbEntity
    {
        private string username;
        private string passwordHash;

        public User(string username, string password, Roles role)
        {
            Username = username;
            PasswordHash = password;
            Role = role;
            Bookings = new List<Booking>();
        }

        public int Id { get; set; }

        public string Username
        {
            get { return this.username; } protected
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format("The username must be at least 5 symbols long."));
                }
                username = value;
            }
        }

        public string PasswordHash
        {
            get { return this.passwordHash; }
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 6)
                {
                    throw new ArgumentException(string.Format("The password must be at least 6 symbols long."));
                }
                passwordHash = HashUtilities.GetSha256Hash(value);
            }
        }

        public Roles Role { get; private set; }
        public ICollection<Booking> Bookings { get; private set; }
    }
}
