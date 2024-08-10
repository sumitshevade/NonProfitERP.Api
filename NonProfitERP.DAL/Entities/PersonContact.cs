namespace NonProfitERP.DAL.Entities
{
    public partial class PersonContact : Entity
    {
        public PersonContact()
        {
            #region Generated Constructor
            #endregion
        }

        #region Generated Properties

        public int PersonId { get; set; }

        public int? ContactTypeId { get; set; }

        public string Detail { get; set; }

        public bool IsDefault { get; set; }

        #endregion

        #region Generated Relationships
        public virtual Detail ContactTypeDetail { get; set; }

        public virtual Person Person { get; set; }

        #endregion

    }
}
