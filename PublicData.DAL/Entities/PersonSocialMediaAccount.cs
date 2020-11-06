namespace PublicData.DAL.Entities
{
    public partial class PersonSocialMediaAccount : Entity
    {
        public PersonSocialMediaAccount()
        {
            #region Generated Constructor
            #endregion
        }

        #region Generated Properties

        public int PersonId { get; set; }

        public int? AccountTypeId { get; set; }

        public string OtherAccountType { get; set; }

        public string Link { get; set; }

        public int TypeOfUserId { get; set; }

        #endregion

        #region Generated Relationships
        public virtual Detail AccountTypeDetail { get; set; }

        public virtual Person Person { get; set; }

        public virtual Detail TypeOfUserDetail { get; set; }

        #endregion

    }
}
