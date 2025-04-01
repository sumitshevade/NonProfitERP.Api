using System.Collections.Generic;

namespace NonProfitERP.DAL.Entities
{
    public partial class University : Entity
    {
        public University()
        {
            #region Generated Constructor
            #endregion
        }

        #region Generated Properties

        public string Name { get; set; }

        public string City { get; set; }

        #endregion

        #region Generated Relationships

        public virtual ICollection<PersonEducation> PersonEducations { get; set; }

        #endregion

    }
}
