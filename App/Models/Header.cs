using System;
using System.Collections.Generic;

namespace App.Models
{
    public partial class Header
    {
        public Header()
        {
            Details = new HashSet<Details>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int CreatedById { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedById { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? DeletedById { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<Details> Details { get; set; }
    }
}
