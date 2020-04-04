using System;
using System.Collections.Generic;

namespace App.Models
{
    public partial class University
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }
        public int CreatedById { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedById { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? DeletedById { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual City City { get; set; }
    }
}
