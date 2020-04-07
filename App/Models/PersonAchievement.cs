using System;
using System.Collections.Generic;

namespace App.Models
{
    public class PersonAchievement
    {
        public int Id { get; set; }
        public int? PersonId { get; set; }
        public string Title { get; set; }
        public string GivenBy { get; set; }
        public string Format { get; set; }
        public string Reason { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public string CreatedById { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedById { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string DeletedById { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual People Person { get; set; }
    }
}
