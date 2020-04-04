using System;
using System.Collections.Generic;

namespace App.Models
{
    public partial class City
    {
        public City()
        {
            PersonAddress = new HashSet<PersonAddress>();
            University = new HashSet<University>();
        }

        public int Id { get; set; }
        public int? StateId { get; set; }
        public string Name { get; set; }
        public int CreatedById { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedById { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? DeletedById { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual State State { get; set; }
        public virtual ICollection<PersonAddress> PersonAddress { get; set; }
        public virtual ICollection<University> University { get; set; }
    }
}
