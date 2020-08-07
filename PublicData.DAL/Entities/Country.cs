using System.Collections.Generic;

namespace PublicData.DAL.Entities
{
    public partial class Country : Entity
    {
        public Country()
        {
            Person = new HashSet<Person>();
            PersonAddress = new HashSet<PersonAddress>();
            State = new HashSet<State>();
        }

        public string Name { get; set; }

        public virtual ICollection<Person> Person { get; set; }
        public virtual ICollection<PersonAddress> PersonAddress { get; set; }
        public virtual ICollection<State> State { get; set; }
    }
}
