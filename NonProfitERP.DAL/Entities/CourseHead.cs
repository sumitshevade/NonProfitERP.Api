using System;

namespace NonProfitERP.DAL.Entities
{
    public partial class CourseHead : Entity
    {
        public CourseHead()
        {
            #region Generated Constructor
            #endregion
        }

        #region Generated Properties

        public int PersonId { get; set; }

        public int CourseId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        #endregion

        #region Generated Relationships
        public virtual Course Course { get; set; }

        public virtual Person Person { get; set; }

        #endregion

    }
}
