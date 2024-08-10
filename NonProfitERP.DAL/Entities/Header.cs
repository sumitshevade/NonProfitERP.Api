using System.Collections.Generic;

namespace NonProfitERP.DAL.Entities
{
    public partial class Header : Entity
    {
        public Header()
        {
            #region Generated Constructor
            Details = new HashSet<Detail>();
            #endregion
        }

        #region Generated Properties

        public string Title { get; set; }

        #endregion

        #region Generated Relationships
        public virtual ICollection<Detail> Details { get; set; }

        #endregion
    }
}
