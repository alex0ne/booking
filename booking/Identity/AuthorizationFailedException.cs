namespace HotelBookingSystem.Identity
{
    using System;
    using Models;

    public class AuthorizationFailedException : ArgumentException
    {
        public AuthorizationFailedException(string message, User user) : base(message)
        {
        }
    }
}
