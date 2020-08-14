using System;
using System.Collections.Generic;

namespace PublicData.DAL.Entities
{
    public partial class Department : Entity
    {
        public Department()
        {
            #region Generated Constructor
            DepartmentHeads = new HashSet<DepartmentHead>();
            Divisions = new HashSet<Division>();
            #endregion
        }

        #region Generated Properties

        public string Name { get; set; }
        public DateTime? StartedAt { get; set; }
        public string LongText { get; set; }

        #endregion

        #region Generated Relationships
        public virtual ICollection<DepartmentHead> DepartmentHeads { get; set; }

        public virtual ICollection<Division> Divisions { get; set; }

        #endregion

    }
}
