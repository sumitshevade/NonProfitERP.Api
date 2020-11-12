namespace PublicData.WebClient.Shared.Models
{
    public partial class PersonSocialMediaAccountModel
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int AccountTypeId { get; set; }
        public string OtherAccountType { get; set; }
        public string Link { get; set; }
        public int TypeOfUserId { get; set; }
        public bool IsActive { get; set; }
    }
}
