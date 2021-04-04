using NonProfitERP.DAL.Entities;
using NonProfitERP.DAL.Interfaces;

namespace NonProfitERP.DAL.Repository
{
    public class CourseHeadRepository : Repository<CourseHead>, ICourseHeadRepository
    {
        public CourseHeadRepository(PublicDataContext context) : base(context)
        {
        }
    }
}
