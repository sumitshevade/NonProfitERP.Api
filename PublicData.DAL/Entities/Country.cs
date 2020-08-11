using System;
using System.Collections.Generic;

namespace PublicData.DAL.Entities
{
    public partial class Country : Entity
    {
        public Country()
        {
            #region Generated Constructor
            People = new HashSet<Person>();
            PersonAddresses = new HashSet<PersonAddress>();
            States = new HashSet<State>();
            #endregion
        }

        #region Generated Properties
        public int Id { get; set; }

        public string Name { get; set; }

        public string CreatedById { get; set; }

        public DateTime CreatedAt { get; set; }

        public string UpdatedById { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public bool IsActive { get; set; }

        #endregion

        #region Generated Relationships
        public virtual ICollection<Person> People { get; set; }

        public virtual ICollection<PersonAddress> PersonAddresses { get; set; }

        public virtual ICollection<State> States { get; set; }

        #endregion

    }
}
