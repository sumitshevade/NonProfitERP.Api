namespace PublicData.DAL.Entities
{
    public partial class University : Entity
    {
        public University()
        {
            #region Generated Constructor
            #endregion
        }

        #region Generated Properties

        public string Name { get; set; }
        public int CityId { get; set; }

        #endregion

        #region Generated Relationships
        public virtual City City { get; set; }

        #endregion

    }
}
