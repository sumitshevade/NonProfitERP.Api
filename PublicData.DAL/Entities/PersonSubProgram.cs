using System;

namespace PublicData.DAL.Entities
{
    public partial class PersonSubProgram : Entity
    {
        public PersonSubProgram()
        {
            #region Generated Constructor
            #endregion
        }

        #region Generated Properties

        public int PersonId { get; set; }

        public int SubProgramId { get; set; }

        public string Role { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string LongText { get; set; }

        #endregion

        #region Generated Relationships
        public virtual Person Person { get; set; }

        public virtual Program SubProgram { get; set; }

        #endregion

    }
}
