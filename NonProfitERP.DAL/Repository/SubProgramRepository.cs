using PublicData.DAL.Entities;
using PublicData.DAL.Interfaces;

namespace PublicData.DAL.Repository
{
    public class SubProgramRepository : Repository<SubProgram>, ISubProgramRepository
    {
        public SubProgramRepository(PublicDataContext context) : base(context)
        {
        }
    }
}
