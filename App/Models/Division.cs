using System;
using System.Collections.Generic;

namespace App.Models
{
    public class Division
    {
        public Division()
        {
            DivisionHeads = new HashSet<DivisionHead>();
        }

        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime StartDate { get; set; }
        public string LongText { get; set; }
        public string CreatedById { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedById { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string DeletedById { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual Department Department { get; set; }
        public virtual ICollection<DivisionHead> DivisionHeads { get; set; }
    }
}
