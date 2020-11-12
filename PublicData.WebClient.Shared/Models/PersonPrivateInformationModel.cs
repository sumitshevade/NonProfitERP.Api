namespace PublicData.WebClient.Shared.Models
{
    public partial class PersonPrivateInformationModel
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public bool MaritalStatus { get; set; }
        public string AadharCardNo { get; set; }
        public bool IsOwnBicycle { get; set; }
        public int? ReligionId { get; set; }
        public string OtherReligion { get; set; }
        public int? CasteId { get; set; }
        public string OtherCaste { get; set; }
        public int? CategoryId { get; set; }
        public string OtherCategory { get; set; }
        public int? ParentalStatusId { get; set; }
        public string OtherParentalStatus { get; set; }
        public bool IsActive { get; set; }
    }
}
