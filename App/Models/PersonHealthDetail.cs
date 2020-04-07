using System;
using System.Collections.Generic;

namespace App.Models
{
    public class PersonHealthDetail
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public double? Height { get; set; }
        public double? Weight { get; set; }
        public double? Iq { get; set; }
        public double? WakeUpTiming { get; set; }
        public double? SleepTiming { get; set; }
        public string CreatedById { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedById { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string DeletedById { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual People Person { get; set; }
    }
}
