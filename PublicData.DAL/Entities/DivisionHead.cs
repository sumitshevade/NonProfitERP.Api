using System;
using System.Collections.Generic;

namespace PublicData.DAL.Entities
{
    public partial class DivisionHead : Entity
    {
        public DivisionHead()
        {
            #region Generated Constructor
            #endregion
        }

        #region Generated Properties

        public int PersonId { get; set; }
        public int DivisionId { get; set; }
        public int FromYear { get; set; }
        public int? ToYear { get; set; }

        #endregion

        #region Generated Relationships
        public virtual Division Division { get; set; }

        public virtual Person Person { get; set; }

        #endregion

    }
}
