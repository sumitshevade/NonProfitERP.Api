using PublicData.DAL.Entities;
using PublicData.DAL.Interfaces;

namespace PublicData.DAL.Repository
{
    public class CourseHeadRepository : Repository<CourseHead>, ICourseHeadRepository
    {
        public CourseHeadRepository(PublicDataContext context) : base(context)
        {
        }
    }
}
