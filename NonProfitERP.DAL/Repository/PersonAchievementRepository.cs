using NonProfitERP.DAL.Entities;
using NonProfitERP.DAL.Interfaces;

namespace NonProfitERP.DAL.Repository
{
    public class PersonAchievementRepository : Repository<PersonAchievement>, IPersonAchievementRepository
    {
        public PersonAchievementRepository(PublicDataContext context) : base(context)
        {
        }
    }
}
