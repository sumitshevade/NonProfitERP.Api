using System;
using System.Collections.Generic;

namespace PublicData.WebClient.DataModels
{
    public partial class PersonWorkExperience
    {
        public PersonWorkExperience()
        {
            #region Generated Constructor
            #endregion
        }

        #region Generated Properties
        public int Id { get; set; }

        public int PersonId { get; set; }

        public int IndustryId { get; set; }

        public string OtherIndustry { get; set; }

        public int? WorkTypeId { get; set; }

        public string OtherWorkType { get; set; }

        public int? StatusId { get; set; }

        public string OtherStatus { get; set; }

        public string CompanyName { get; set; }

        public string ActualWork { get; set; }

        public int? FromYear { get; set; }

        public int? ToYear { get; set; }

        public string LongText { get; set; }

        public string CreatedById { get; set; }

        public DateTime CreatedAt { get; set; }

        public string UpdatedById { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public bool IsActive { get; set; }

        #endregion

        #region Generated Relationships
        public virtual Detail IndustryDetail { get; set; }

        public virtual Person Person { get; set; }

        public virtual Detail StatusDetail { get; set; }

        public virtual Detail WorkTypeDetail { get; set; }

        #endregion

    }
}
