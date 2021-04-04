using Microsoft.EntityFrameworkCore.Query;
using PublicData.Common.Interfaces;
using PublicData.DAL.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;

namespace PublicData.DAL.Interfaces
{
    public interface IPersonRepository : IRepository<Person>
    {
    }
}
