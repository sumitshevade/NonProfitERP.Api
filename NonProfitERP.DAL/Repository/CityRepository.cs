using System.Linq;
using Microsoft.EntityFrameworkCore;
using NonProfitERP.DAL.Entities;
using NonProfitERP.DAL.Interfaces;

namespace NonProfitERP.DAL.Repository
{
    public class CityRepository(PublicDataContext context) : Repository<City>(context), ICityRepository
    {
        public IQueryable<City> SearchCity(string city)
        {
            // Can not implement this in main repository as Name is not in TEntity
            return _context.Cities.Where(e => EF.Functions.Like(e.Name, city + '%') && e.IsActive == true);
        }
    }
}
