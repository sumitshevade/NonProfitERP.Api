using PublicData.Application.Mappings;
using PublicData.DAL.Entities;
using System;

namespace PublicData.Application.Shared
{
    public partial class PersonAchievementModel : IMapFrom<PersonAchievement>
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string Title { get; set; }
        public string GivenBy { get; set; }
        public string Format { get; set; }
        public string Reason { get; set; }
        public int? AwardLevelId { get; set; }
        public DateTime? ReceivedDate { get; set; }

        public virtual Detail AwardLevel { get; set; }
        public virtual Person Person { get; set; }
    }
}
