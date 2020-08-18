using System;
using System.Collections.Generic;

namespace PublicData.DAL.Entities
{
    public partial class Division : Entity
    {
        public Division()
        {
            #region Generated Constructor
            DivisionHeads = new HashSet<DivisionHead>();
            #endregion
        }

        #region Generated Properties
        
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime StartDate { get; set; }
        public string LongText { get; set; }

        #endregion

        #region Generated Relationships
        public virtual Department Department { get; set; }

        public virtual ICollection<DivisionHead> DivisionHeads { get; set; }

        #endregion

    }
}
