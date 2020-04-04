using System;
using System.Collections.Generic;

namespace App.Models
{
    public partial class State
    {
        public State()
        {
            City = new HashSet<City>();
            PersonAddress = new HashSet<PersonAddress>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? CountryId { get; set; }
        public int CreatedById { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedById { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? DeletedById { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<City> City { get; set; }
        public virtual ICollection<PersonAddress> PersonAddress { get; set; }
    }
}
