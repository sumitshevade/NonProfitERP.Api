using System;

namespace PublicData.WebClient.Shared.Entities
{
    public partial class PersonAchievement
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string Title { get; set; }
        public string GivenBy { get; set; }
        public string Format { get; set; }
        public string Reason { get; set; }
        public int? AwardLevelId { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
