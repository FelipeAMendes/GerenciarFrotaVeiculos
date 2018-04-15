using ManageFleet.Infra.Data.Context;
using ManageFleet.Infra.Data.Interfaces;
using System;

namespace ManageFleet.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ManageFleetContext _context;
        private bool _disposed;

        public UnitOfWork(ManageFleetContext context)
        {
            _context = context;
        }

        public void BeginTransaction()
        {
            _disposed = false;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
        
        // Dispose Pattern
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}