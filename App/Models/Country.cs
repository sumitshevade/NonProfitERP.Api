using System;
using System.Collections.Generic;

namespace App.Models
{
    public class Country
    {
        public Country()
        {
            People = new HashSet<People>();
            PersonAddresses = new HashSet<PersonAddress>();
            States = new HashSet<State>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string CreatedById { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedById { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string DeletedById { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<People> People { get; set; }
        public virtual ICollection<PersonAddress> PersonAddresses { get; set; }
        public virtual ICollection<State> States { get; set; }
    }
}
