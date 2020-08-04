using PublicData.Data.Entities;
using PublicData.Data.Interfaces;

namespace PublicData.Data.Repository
{
    public class PersonAchievementRepository : Repository<PersonAchievement>, IPersonAchievementRepository
    {
        public PersonAchievementRepository(PublicDataContext context) : base(context)
        {
        }
    }
}
