namespace PublicData.WebClient.Shared.Models
{
    public partial class PersonWorkExperienceModel
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int IndustryId { get; set; }
        public string OtherIndustry { get; set; }
        public int? WorkTypeId { get; set; }
        public string OtherWorkType { get; set; }
        public int? StatusId { get; set; }
        public string OtherStatus { get; set; }
        public string CompanyName { get; set; }
        public string ActualWork { get; set; }
        public int? FromYear { get; set; }
        public int? ToYear { get; set; }
        public string LongText { get; set; }
        public bool IsActive { get; set; }
    }
}
