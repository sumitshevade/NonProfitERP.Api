using System.Collections.Generic;

namespace NonProfitERP.DAL.Entities
{
    public partial class Organization : Entity
    {
        public Organization()
        {
            #region Generated Constructor
            PersonFamilyDetails = new HashSet<PersonFamilyDetail>();
            PersonWorkExperiences = new HashSet<PersonWorkExperience>();
            #endregion
        }

        #region Generated Properties

        public string Name { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string WebLink { get; set; }

        public string ContactNo { get; set; }

        #endregion

        #region Generated Relationships
        public virtual ICollection<PersonFamilyDetail> PersonFamilyDetails { get; set; }

        public virtual ICollection<PersonWorkExperience> PersonWorkExperiences { get; set; }

        #endregion

    }
}
