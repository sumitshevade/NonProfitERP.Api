using System;
using System.Collections.Generic;

namespace NonProfitERP.DAL.Entities;

public partial class District : Entity
{
    public District()
    {
        #region Generated Constructor
        PersonAddresses = new HashSet<PersonAddress>();
        Schools = new HashSet<School>();
        Talukas = new HashSet<Taluka>();
        #endregion
    }

    #region Generated Properties

    public int StateId { get; set; }

    public string Name { get; set; }

    public string LongText { get; set; }

    #endregion

    #region Generated Relationships
    public virtual ICollection<PersonAddress> PersonAddresses { get; set; }

    public virtual ICollection<School> Schools { get; set; } = new List<School>();

    public virtual State State { get; set; }

    public virtual ICollection<Taluka> Talukas { get; set; } = new List<Taluka>();

    #endregion
}
