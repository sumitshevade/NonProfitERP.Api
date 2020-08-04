
using FluentValidation.Results;
using PublicData.Common.Interfaces;
using System;

namespace PublicData.Data
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
            catch (Exception ex)
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
