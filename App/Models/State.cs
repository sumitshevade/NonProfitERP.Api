using System;
using System.Collections.Generic;

namespace App.Models
{
    public class State
    {
        public State()
        {
            Cities = new HashSet<City>();
            PersonAddresses = new HashSet<PersonAddress>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? CountryId { get; set; }
        public string CreatedById { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedById { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string DeletedById { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<City> Cities { get; set; }
        public virtual ICollection<PersonAddress> PersonAddresses { get; set; }
    }
}
