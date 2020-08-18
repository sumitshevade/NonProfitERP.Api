namespace PublicData.DAL.Entities
{
    public partial class PersonPrivateInformation : Entity
    {
        public PersonPrivateInformation()
        {
            #region Generated Constructor
            #endregion
        }

        #region Generated Properties

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

        #endregion

        #region Generated Relationships
        public virtual Detail CasteDetail { get; set; }

        public virtual Detail CategoryDetail { get; set; }

        public virtual Detail ParentalStatusDetail { get; set; }

        public virtual Person Person { get; set; }

        public virtual Detail ReligionDetail { get; set; }

        #endregion

    }
}
