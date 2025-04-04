using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NonProfitERP.DAL.Entities;
using NonProfitERP.DAL.Interfaces;

namespace NonProfitERP.DAL.Repository
{
    public class CustomRepository(PublicDataContext context) : ICustomRepository
    {
        protected readonly PublicDataContext _context = context;

        public virtual async Task<Root> GetPageData(string entities)
        {
            var contextList = entities.Split(',');
            Root root = new Root();

            foreach (var item in contextList)
            {
                switch (item.Trim())
                {
                    case "state":
                        var states = await _context.States.Where(x => x.IsActive == true).ToListAsync();
                        root.States = states;
                        break;
                    case "schooltype":
                        var st = await _context.Details.Where(x => x.Id == 4 && x.IsActive == true).ToListAsync();
                        root.SchoolType = st;
                        break;
                    case "syllabus":
                        var sl = await _context.Details.Where(x => x.Id == 2 && x.IsActive == true).ToListAsync();
                        root.Syllabus = sl;
                        break;
                    default:
                        break;
                }
            }

            return root;
        }
    }
}
