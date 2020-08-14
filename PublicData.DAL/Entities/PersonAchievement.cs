using System;
using System.Collections.Generic;

namespace PublicData.DAL.Entities
{
    public partial class PersonAchievement : Entity
    {
        public PersonAchievement()
        {
            #region Generated Constructor
            #endregion
        }

        #region Generated Properties

        public int PersonId { get; set; }
        public string Title { get; set; }
        public string GivenBy { get; set; }
        public string Format { get; set; }
        public string Reason { get; set; }
        public int? AwardLevelId { get; set; }
        public DateTime? ReceivedDate { get; set; }

        #endregion

        #region Generated Relationships
        public virtual Detail AwardLevelDetail { get; set; }

        public virtual Person Person { get; set; }

        #endregion

    }
}
