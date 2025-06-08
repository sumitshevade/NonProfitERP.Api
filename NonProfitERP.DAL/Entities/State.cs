using System.Collections.Generic;

namespace NonProfitERP.DAL.Entities;

public partial class State : Entity
{
    public State()
    {
        #region Generated Constructor
        Cities = new HashSet<City>();
        Districts = new HashSet<District>();
        PersonAddresses = new HashSet<PersonAddress>();
        Schools = new HashSet<School>();
        #endregion
    }

    #region Generated Properties

    public int CountryId { get; set; }

    public string Name { get; set; }

    #endregion

    #region Generated Relationships
    public virtual ICollection<City> Cities { get; set; }

    public virtual Country Country { get; set; }

    public virtual ICollection<District> Districts { get; set; } = new List<District>();

    public virtual ICollection<PersonAddress> PersonAddresses { get; set; }

    public virtual ICollection<School> Schools { get; set; }

    #endregion
}
