using System;
using System.Collections.Generic;

namespace PublicData.DAL.Entities
{
    public partial class PersonLanguage : Entity
    {
        public PersonLanguage()
        {
            #region Generated Constructor
            #endregion
        }

        #region Generated Properties
        public int Id { get; set; }

        public int PersonId { get; set; }

        public int LanguageId { get; set; }

        public string OtherLanguage { get; set; }

        public bool IsMotherTongue { get; set; }

        public string CreatedById { get; set; }

        public DateTime CreatedAt { get; set; }

        public string UpdatedById { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public bool IsActive { get; set; }

        #endregion

        #region Generated Relationships
        public virtual Detail LanguageDetail { get; set; }

        public virtual Person Person { get; set; }

        #endregion

    }
}
