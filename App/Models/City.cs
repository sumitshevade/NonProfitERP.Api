using System;
using System.Collections.Generic;

namespace App.Models
{
    public class City
    {
        public City()
        {
            PersonAddresses = new HashSet<PersonAddress>();
            Universities = new HashSet<University>();
        }

        public int Id { get; set; }
        public int? StateId { get; set; }
        public string Name { get; set; }
        public string CreatedById { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedById { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string DeletedById { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual State State { get; set; }
        public virtual ICollection<PersonAddress> PersonAddresses { get; set; }
        public virtual ICollection<University> Universities { get; set; }
    }
}
