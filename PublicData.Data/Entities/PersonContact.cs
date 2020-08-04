using System;

namespace PublicData.Data.Entities
{
    public partial class PersonContact : Entity
    {
        public int PersonId { get; set; }
        public int? ContactTypeId { get; set; }
        public string Detail { get; set; }
        public bool IsDefault { get; set; }

        public virtual Detail ContactType { get; set; }
        public virtual Person Person { get; set; }
    }
}
