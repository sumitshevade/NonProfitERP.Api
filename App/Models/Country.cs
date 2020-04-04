using System;
using System.Collections.Generic;

namespace App.Models
{
    public partial class Country
    {
        public Country()
        {
            Person = new HashSet<Person>();
            PersonAddress = new HashSet<PersonAddress>();
            State = new HashSet<State>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int CreatedById { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedById { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? DeletedById { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<Person> Person { get; set; }
        public virtual ICollection<PersonAddress> PersonAddress { get; set; }
        public virtual ICollection<State> State { get; set; }
    }
}
