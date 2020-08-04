using System;
using System.Collections.Generic;

namespace PublicData.Data.Entities
{
    public partial class District : Entity
    {
        public District()
        {
            PersonAddress = new HashSet<PersonAddress>();
            Taluka = new HashSet<Taluka>();
        }

        public int? StateId { get; set; }
        public string Name { get; set; }
        public string LongText { get; set; }

        public virtual State State { get; set; }
        public virtual ICollection<PersonAddress> PersonAddress { get; set; }
        public virtual ICollection<Taluka> Taluka { get; set; }
    }
}
