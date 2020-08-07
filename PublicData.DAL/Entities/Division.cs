using System;
using System.Collections.Generic;

namespace PublicData.DAL.Entities
{
    public partial class Division : Entity
    {
        public Division()
        {
            DivisionHead = new HashSet<DivisionHead>();
        }

        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime StartDate { get; set; }
        public string LongText { get; set; }

        public virtual Department Department { get; set; }
        public virtual ICollection<DivisionHead> DivisionHead { get; set; }
    }
}
