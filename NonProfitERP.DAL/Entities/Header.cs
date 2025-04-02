using System.Collections.Generic;
using System.Text.Json.Serialization;

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

        public string Name { get; set; }

        #endregion

        #region Generated Relationships
        public virtual ICollection<Detail> Details { get; set; }

        #endregion
    }
}
