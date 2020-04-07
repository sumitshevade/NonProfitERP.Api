using System;
using System.Collections.Generic;

namespace App.Models
{
    public class PersonContact
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int? ContactType { get; set; }
        public string Detail { get; set; }
        public bool IsDefault { get; set; }
        public string CreatedById { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedById { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string DeletedById { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual Detail ContactTypeNavigation { get; set; }
        public virtual People Person { get; set; }
    }
}
