using System;
using System.Collections.Generic;

namespace PublicData.Data.Entities
{
    public partial class Department : Entity
    {
        public Department()
        {
            DepartmentHead = new HashSet<DepartmentHead>();
            Division = new HashSet<Division>();
        }

        public string Name { get; set; }
        public DateTime? StartedAt { get; set; }
        public string LongText { get; set; }

        public virtual ICollection<DepartmentHead> DepartmentHead { get; set; }
        public virtual ICollection<Division> Division { get; set; }
    }
}
