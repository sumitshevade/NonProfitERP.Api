using PublicData.DAL.Entities;
using PublicData.DAL.Interfaces;

namespace PublicData.DAL.Repository
{
    public class ProgramRepository : Repository<Program>, IProgramRepository
    {
        public ProgramRepository(PublicDataContext context) : base(context)
        {
        }
    }
}
