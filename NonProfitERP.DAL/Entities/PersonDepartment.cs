using System;

namespace NonProfitERP.DAL.Entities
{
    public partial class PersonDepartment : Entity
    {
        public PersonDepartment()
        {
            #region Generated Constructor
            #endregion
        }

        #region Generated Properties

        public int PersonId { get; set; }

        public int DepartmentId { get; set; }

        public string Role { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string LongText { get; set; }

        #endregion

        #region Generated Relationships
        public virtual Department Department { get; set; }

        public virtual Person Person { get; set; }

        #endregion

    }
}
