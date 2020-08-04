using System;

namespace PublicData.Common.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}
