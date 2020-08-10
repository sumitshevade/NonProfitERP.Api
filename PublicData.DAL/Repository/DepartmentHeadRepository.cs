using PublicData.DAL.Entities;
using PublicData.DAL.Interfaces;

namespace PublicData.DAL.Repository
{
    public class DepartmentHeadRepository : Repository<DepartmentHead>, IDepartmentHeadRepository
    {
        public DepartmentHeadRepository(PublicDataContext context) : base(context)
        {
        }
    }
}
