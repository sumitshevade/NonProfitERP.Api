using NonProfitERP.DAL.Entities;
using NonProfitERP.DAL.Interfaces;

namespace NonProfitERP.DAL.Repository
{
    public class ProgramRepository : Repository<Program>, IProgramRepository
    {
        public ProgramRepository(PublicDataContext context) : base(context)
        {
        }
    }
}
