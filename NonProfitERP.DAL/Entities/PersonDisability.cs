namespace NonProfitERP.DAL.Entities
{
    public partial class PersonDisability : Entity
    {
        public PersonDisability()
        {
            #region Generated Constructor
            #endregion
        }

        #region Generated Properties
        
        public int PersonId { get; set; }

        public string Problem { get; set; }

        public string Detail { get; set; }

        public int? FromYear { get; set; }

        public int? ToYear { get; set; }

        #endregion

        #region Generated Relationships
        public virtual Person Person { get; set; }

        #endregion

    }
}
