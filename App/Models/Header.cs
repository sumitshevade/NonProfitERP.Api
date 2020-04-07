using System;
using System.Collections.Generic;

namespace App.Models
{
    public class Header
    {
        public Header()
        {
            Details = new HashSet<Detail>();
        }

        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public string Title { get; set; }
        public string CreatedById { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedById { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string DeletedById { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual Organization Organization { get; set; }
        public virtual ICollection<Detail> Details { get; set; }
    }
}
