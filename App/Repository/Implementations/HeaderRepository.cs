using App.Models;
using App.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Repository.Implementations
{
    public class HeaderRepository : GenericRepositoy<Header>, IHeaderRepository
    {
        public HeaderRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
