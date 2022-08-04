using System;
using InvoiceMgmt.ApplicationCore.Entities;
using InvoiceMgmt.ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InvoiceMgmt.Infrastructure.Data.InMemoryDB
{
    public class InMemoryRepository : IRepository
    {
        private readonly AppDbContext _dbContext;

        public InMemoryRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Invoice item, CancellationToken cancellationToken = default)
        {
            await _dbContext.Set<Invoice>().AddAsync(item, cancellationToken);
        }

        public async Task<int> CountAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<Invoice>().CountAsync(cancellationToken);
        }

        public async Task DeleteAsync(Invoice item, CancellationToken cancellationToken = default)
        {
            await Task.Run(() => _dbContext.Set<Invoice>().Remove(item), cancellationToken);
        }

        public async Task<IEnumerable<Invoice>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<Invoice>().ToListAsync();
        }

        public async Task<Invoice> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<Invoice>().FirstOrDefaultAsync(i => i.Id == id, cancellationToken);
        }

        public async Task<int> SaveAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(Invoice item, CancellationToken cancellationToken = default)
        {
            await Task.Run(() => _dbContext.Set<Invoice>().Update(item), cancellationToken);
        }
    }
}

