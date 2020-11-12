using System;

namespace PublicData.DAL.Entities
{
    public partial class PersonProgram : Entity
    {
        public PersonProgram()
        {
            #region Generated Constructor
            #endregion
        }

        #region Generated Properties

        public int PersonId { get; set; }

        public int ProgramId { get; set; }

        public string Role { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string LongText { get; set; }

        #endregion

        #region Generated Relationships
        public virtual Person Person { get; set; }

        public virtual Program Program { get; set; }

        #endregion

    }
}
