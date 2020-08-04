namespace PublicData.Data.Entities
{
    public partial class PersonSocialMediaAccount : Entity
    {
        public int PersonId { get; set; }
        public int AccountTypeId { get; set; }
        public string OtherAccountType { get; set; }
        public string Link { get; set; }
        public int TypeOfUserId { get; set; }

        public virtual Detail AccountType { get; set; }
        public virtual Person Person { get; set; }
        public virtual Detail TypeOfUser { get; set; }
    }
}
