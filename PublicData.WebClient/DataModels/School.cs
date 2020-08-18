using System;
using System.Collections.Generic;

namespace PublicData.WebClient.DataModels
{
    public partial class School
    {
        public School()
        {
            #region Generated Constructor
            PersonEducations = new HashSet<PersonEducation>();
            #endregion
        }

        #region Generated Properties
        public int Id { get; set; }

        public string Name { get; set; }

        public string ContactPersonName { get; set; }

        public string ContactPersonContactNo { get; set; }

        public string Address { get; set; }

        public string PhoneNo { get; set; }

        public string Email { get; set; }

        public string Website { get; set; }

        public int? SchoolTypeId { get; set; }

        public string CreatedById { get; set; }

        public DateTime CreatedAt { get; set; }

        public string UpdatedById { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public bool IsActive { get; set; }

        #endregion

        #region Generated Relationships
        public virtual ICollection<PersonEducation> PersonEducations { get; set; }

        public virtual Detail TypeDetail { get; set; }

        #endregion

    }
}
