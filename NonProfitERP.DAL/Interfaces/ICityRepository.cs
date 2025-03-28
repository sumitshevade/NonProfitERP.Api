using System.Linq;
using NonProfitERP.Common.Interfaces;
using NonProfitERP.DAL.Entities;

namespace NonProfitERP.DAL.Interfaces
{
    public interface ICityRepository : IRepository<City>
    {
        IQueryable<City> SearchCity(string city);
    }
}
