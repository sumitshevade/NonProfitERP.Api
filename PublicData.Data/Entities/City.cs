using System.Collections.Generic;

namespace PublicData.Data.Entities
{
    public partial class City : Entity
    {
        public City()
        {
            PersonAddress = new HashSet<PersonAddress>();
            University = new HashSet<University>();
        }

        public int? StateId { get; set; }
        public string Name { get; set; }

        public virtual State State { get; set; }
        public virtual ICollection<PersonAddress> PersonAddress { get; set; }
        public virtual ICollection<University> University { get; set; }
    }
}
