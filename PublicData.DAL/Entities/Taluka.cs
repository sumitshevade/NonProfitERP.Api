using System.Collections.Generic;

namespace PublicData.DAL.Entities
{
    public partial class Taluka : Entity
    {
        public Taluka()
        {
            #region Generated Constructor
            PersonAddresses = new HashSet<PersonAddress>();
            #endregion
        }

        #region Generated Properties

        public int? DistrictId { get; set; }
        public string Name { get; set; }
        public string LongText { get; set; }

        #endregion

        #region Generated Relationships
        public virtual District District { get; set; }

        public virtual ICollection<PersonAddress> PersonAddresses { get; set; }

        #endregion

    }
}
