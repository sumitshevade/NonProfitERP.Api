using System;

namespace NonProfitERP.DAL.Entities
{
    public partial class Batch : Entity
    {
        public Batch()
        {
            #region Generated Constructor
            #endregion
        }

        #region Generated Properties
        public int CourseId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string Year { get; set; }

        public string ContactNo { get; set; }

        public string Email { get; set; }

        public string LongText { get; set; }

        #endregion

        #region Generated Relationships
        public virtual Course Course { get; set; }

        #endregion

    }
}
