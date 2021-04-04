namespace PublicData.DAL.Entities
{
    public partial class PersonHobbyFavorite : Entity
    {
        public PersonHobbyFavorite()
        {
            #region Generated Constructor
            #endregion
        }

        #region Generated Properties
        
        public int PersonId { get; set; }

        public int? HobbyFavoriteId { get; set; }

        public string LongText { get; set; }

        #endregion

        #region Generated Relationships
        public virtual Detail HobbyFavoriteDetail { get; set; }

        public virtual Person Person { get; set; }

        #endregion

    }
}
