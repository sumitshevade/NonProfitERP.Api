using System;

namespace NonProfitERP.Common.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}
