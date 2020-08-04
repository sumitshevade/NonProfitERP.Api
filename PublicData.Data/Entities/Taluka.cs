using System.Collections.Generic;

namespace PublicData.Data.Entities
{
    public partial class Taluka : Entity
    {
        public Taluka()
        {
            PersonAddress = new HashSet<PersonAddress>();
        }

        public int? DistrictId { get; set; }
        public string Name { get; set; }
        public string LongText { get; set; }

        public virtual District District { get; set; }
        public virtual ICollection<PersonAddress> PersonAddress { get; set; }
    }
}
