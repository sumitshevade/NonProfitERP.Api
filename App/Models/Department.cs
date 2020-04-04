using System;
using System.Collections.Generic;

namespace App.Models
{
    public partial class Department
    {
        public Department()
        {
            DepartmentHead = new HashSet<DepartmentHead>();
            Division = new HashSet<Division>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? StartedAt { get; set; }
        public string LongText { get; set; }
        public int CreatedById { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedById { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? DeletedById { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<DepartmentHead> DepartmentHead { get; set; }
        public virtual ICollection<Division> Division { get; set; }
    }
}
