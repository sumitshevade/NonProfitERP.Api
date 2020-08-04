using System;

namespace PublicData.Data.Entities
{
    public partial class DepartmentHead : Entity
    {
        public int PersonId { get; set; }
        public int DepartmentId { get; set; }
        public int FromYear { get; set; }
        public int? ToYear { get; set; }

        public virtual Department Department { get; set; }
        public virtual Person Person { get; set; }
    }
}
