namespace PublicData.DAL.Entities
{
    public partial class PersonPrivateInformation : Entity
    {
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

        public virtual Detail Caste { get; set; }
        public virtual Detail Category { get; set; }
        public virtual Detail ParentalStatus { get; set; }
        public virtual Person Person { get; set; }
        public virtual Detail Religion { get; set; }
    }
}
