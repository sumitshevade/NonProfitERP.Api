using System.Collections.Generic;

namespace PublicData.DAL.Entities
{
    public partial class State : Entity
    {
        public State()
        {
            City = new HashSet<City>();
            District = new HashSet<District>();
            PersonAddress = new HashSet<PersonAddress>();
        }

        public string Name { get; set; }
        public int? CountryId { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<City> City { get; set; }
        public virtual ICollection<District> District { get; set; }
        public virtual ICollection<PersonAddress> PersonAddress { get; set; }
    }
}
