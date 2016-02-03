namespace HotelBookingSystem.Models
{
    using System;
    using System.Collections.Generic;
    using Interfaces;

    public class Venue : IDbEntity
    {
        private readonly string name = string.Empty;
        private string address;
        private User currentUser;

        public Venue(string name, string address, string description, User owner, ICollection<Room> rooms)
        {
            this.Name = name;
            this.Address = address;
            this.Description = description;
            this.Rooms = rooms;
        }

        public Venue(string name, string address, string description, User currentUser)
        {
            this.name = name;
            this.address = address;
            this.Description = description;
            this.currentUser = currentUser;
        }

        public int Id { get; set; }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 3)
                {
                    throw new ArgumentException("The venue name must be at least 3 symbols long.");
                }
            }
        }

        public string Address
        {
            get
            {
                return this.address;
            }

            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 3)
                {
                    throw new ArgumentException("The venue address must be at least 3 symbols long.");
                }

                this.address = value;
            }
        }

        public string Description { get; private set; }

        public ICollection<Room> Rooms { get; private set; }
    }
}
