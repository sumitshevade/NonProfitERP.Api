using Microsoft.EntityFrameworkCore.Query;
using NonProfitERP.Common.Interfaces;
using NonProfitERP.DAL.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;

namespace NonProfitERP.DAL.Interfaces
{
    public interface IPersonRepository : IRepository<Person>
    {
    }
}
