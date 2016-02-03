namespace HotelBookingSystem.Identity
{
    using HotelBookingSystem.Models;
    using System;

    public class AuthorizationFailedException : ArgumentException
    {
        public AuthorizationFailedException(string message, User user) : base(message)
        {
            this.User = user;
        }

        public User User { get; set; }
    }
}
