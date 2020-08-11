using System;
using System.Collections.Generic;

namespace PublicData.DAL.Entities
{
    public partial class PersonHealthDetail : Entity
    {
        public PersonHealthDetail()
        {
            #region Generated Constructor
            #endregion
        }

        #region Generated Properties
        public int Id { get; set; }

        public int PersonId { get; set; }

        public double? Height { get; set; }

        public double? Weight { get; set; }

        public double? Iq { get; set; }

        public double? WakeUpTiming { get; set; }

        public double? SleepTiming { get; set; }

        public string CreatedById { get; set; }

        public DateTime CreatedAt { get; set; }

        public string UpdatedById { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public bool IsActive { get; set; }

        #endregion

        #region Generated Relationships
        public virtual Person Person { get; set; }

        #endregion

    }
}
