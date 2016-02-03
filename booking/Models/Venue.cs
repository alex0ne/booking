using System.Collections.Generic;
using System;
namespace HotelBookingSystem.Models
{
    public class Venue : IDbEntity
    {
        public int Id { get; set; }
        public string Name
        {
            get { return this.name; }
            private set
            {

                if (string.IsNullOrEmpty(value) || value.Length < 3)
                {
                    throw new ArgumentException(string.Format("The venue name must be at least 3 symbols long."));
                }
            }
        }
        public string Address
        {
            get { return this.address; }
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 3) 
                    throw new ArgumentException(string.Format("The venue address must be at least 3 symbols long."));
                this.address = value;
            }
        }
        public string Description { get; set; }
        public User Owner { get; set; }
        public ICollection<Room> Rooms { get; set; }

        public Venue(string name, string address, string description, User owner)
        {
            Name = name;
            this.Address = address;
            Description = description;
            this.Owner = owner;
        }

        private string name = string.Empty;
       private string address;
    }
}
