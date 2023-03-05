using System;
using System.Data.Entity;
using ContractsService.Data.Models;

namespace ContractsService.Data.Repositories
{
    public sealed class ApplicationUnitOfWork : IDisposable
    {
        private readonly ApplicationContext _context;
        private ContractsRepository _contractRepository;
        private bool _disposed;
        
        public IRepository<ContractEntity> ContractRepository => 
            _contractRepository ?? (_contractRepository = new ContractsRepository(_context));

        public ApplicationUnitOfWork(string connectionString)
        {
            _context = new ApplicationContext(connectionString);
        }
        
        public void Save()
        {
            _context.SaveChanges();
        }
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed)
                if (disposing)
                    _context.Dispose();
            _disposed = true;
        }
    }
}