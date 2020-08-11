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
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime? StartedAt { get; set; }

        public string LongText { get; set; }

        public string CreatedById { get; set; }

        public DateTime CreatedAt { get; set; }

        public string UpdatedById { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public bool IsActive { get; set; }

        #endregion

        #region Generated Relationships
        public virtual ICollection<DepartmentHead> DepartmentHeads { get; set; }

        public virtual ICollection<Division> Divisions { get; set; }

        #endregion

    }
}
