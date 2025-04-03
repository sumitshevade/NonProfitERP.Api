using System;
using System.Collections.Generic;

namespace NonProfitERP.DAL.Entities;

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

    public string Name { get; set; }
    #endregion

    #region Generated Relationships
    public virtual ICollection<Person> People { get; set; }

    public virtual ICollection<PersonAddress> PersonAddresses { get; set; }

    public virtual ICollection<State> States { get; set; } = new List<State>();
    #endregion
}
