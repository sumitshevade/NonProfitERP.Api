using System;
using System.Collections.Generic;

namespace App.Models
{
    public partial class PersonAchievement
    {
        public int Id { get; set; }
        public int? PersonId { get; set; }
        public string Title { get; set; }
        public string GivenBy { get; set; }
        public string Format { get; set; }
        public string Reason { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public int CreatedById { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedById { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? DeletedById { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual Person Person { get; set; }
    }
}
