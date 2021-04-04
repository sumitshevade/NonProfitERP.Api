using System.Collections.Generic;

namespace NonProfitERP.DAL.Entities
{
    public partial class School : Entity
    {
        public School()
        {
            #region Generated Constructor
            PersonEducations = new HashSet<PersonEducation>();
            #endregion
        }

        #region Generated Properties

        public string Name { get; set; }

        public string ContactPersonName { get; set; }

        public string ContactPersonDesignation { get; set; }

        public string ContactPersonContactNo { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public int? TalukaId { get; set; }

        public string OtherTaluka { get; set; }

        public int? DistrictId { get; set; }

        public string OtherDistrict { get; set; }

        public int? StateId { get; set; }

        public string PhoneNo { get; set; }

        public string Email { get; set; }

        public string WebLink { get; set; }

        public int? SchoolTypeId { get; set; }

        public string LongText { get; set; }

        #endregion

        #region Generated Relationships
        public virtual District District { get; set; }

        public virtual ICollection<PersonEducation> PersonEducations { get; set; }

        public virtual State State { get; set; }

        public virtual Taluka Taluka { get; set; }

        public virtual Detail TypeDetail { get; set; }

        #endregion

    }
}
