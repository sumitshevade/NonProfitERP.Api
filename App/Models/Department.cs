using System;
using System.Collections.Generic;

namespace App.Models
{
    public class Department
    {
        public Department()
        {
            DepartmentHeads = new HashSet<DepartmentHead>();
            Divisions = new HashSet<Division>();
        }

        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public string Name { get; set; }
        public DateTime? StartedAt { get; set; }
        public string LongText { get; set; }
        public string CreatedById { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedById { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string DeletedById { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual Organization Organization { get; set; }
        public virtual ICollection<DepartmentHead> DepartmentHeads { get; set; }
        public virtual ICollection<Division> Divisions { get; set; }
    }
}
