using System;

namespace PublicData.DAL.Entities
{
    public partial class DivisionHead : Entity
    {
        public int PersonId { get; set; }
        public int DivisionId { get; set; }
        public int FromYear { get; set; }
        public int? ToYear { get; set; }

        public virtual Division Division { get; set; }
        public virtual Person Person { get; set; }
    }
}
