using NonProfitERP.Common.Interfaces;
using System;

namespace NonProfitERP.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PublicDataContext _context;

        public UnitOfWork(PublicDataContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            try
            {
                var result = _context.SaveChangesAsync().GetAwaiter().GetResult();
                return result > 0;
            }
            catch (Exception)
            {
            }
            return false;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
