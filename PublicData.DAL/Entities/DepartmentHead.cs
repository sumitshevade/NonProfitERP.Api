using System;
using System.Collections.Generic;

namespace PublicData.DAL.Entities
{
    public partial class DepartmentHead : Entity
    {
        public DepartmentHead()
        {
            #region Generated Constructor
            #endregion
        }

        #region Generated Properties

        public int PersonId { get; set; }
        public int DepartmentId { get; set; }
        public int FromYear { get; set; }
        public int? ToYear { get; set; }

        #endregion

        #region Generated Relationships
        public virtual Department Department { get; set; }

        public virtual Person Person { get; set; }

        #endregion

    }
}
