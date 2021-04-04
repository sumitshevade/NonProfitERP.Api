using NonProfitERP.DAL.Entities;
using NonProfitERP.DAL.Interfaces;

namespace NonProfitERP.DAL.Repository
{
    public class SubProgramRepository : Repository<SubProgram>, ISubProgramRepository
    {
        public SubProgramRepository(PublicDataContext context) : base(context)
        {
        }
    }
}
