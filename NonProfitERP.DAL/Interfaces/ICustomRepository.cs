using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NonProfitERP.DAL.Entities;

namespace NonProfitERP.DAL.Interfaces
{
    public interface ICustomRepository
    {
        Task<Root> GetPageData(string entities);
    }
}
