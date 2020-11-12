using PublicData.DAL.Entities;
using PublicData.DAL.Interfaces;

namespace PublicData.DAL.Repository
{
    public class PersonAchievementRepository : Repository<PersonAchievement>, IPersonAchievementRepository
    {
        public PersonAchievementRepository(PublicDataContext context) : base(context)
        {
        }
    }
}
