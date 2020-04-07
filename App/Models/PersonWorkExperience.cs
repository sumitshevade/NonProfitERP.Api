using System;
using System.Collections.Generic;

namespace App.Models
{
    public class PersonWorkExperience
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int IndustryId { get; set; }
        public int? WorkTypeId { get; set; }
        public string CompanyName { get; set; }
        public string ActualWork { get; set; }
        public int? FromYear { get; set; }
        public int? ToYear { get; set; }
        public string LongText { get; set; }
        public string CreatedById { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedById { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string DeletedById { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual Detail Industry { get; set; }
        public virtual People Person { get; set; }
        public virtual Detail WorkType { get; set; }
    }
}
