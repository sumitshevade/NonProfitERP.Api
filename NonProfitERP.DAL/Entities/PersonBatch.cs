using System;
using System.Collections.Generic;

namespace NonProfitERP.DAL.Entities
{
    public partial class PersonBatch : Entity
    {
        public PersonBatch()
        {
            #region Generated Constructor
            #endregion
        }

        #region Generated Properties
        
        public int PersonId { get; set; }

        public string Role { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string LongText { get; set; }

        #endregion

        #region Generated Relationships
        public virtual Person Person { get; set; }

        #endregion

    }
}
