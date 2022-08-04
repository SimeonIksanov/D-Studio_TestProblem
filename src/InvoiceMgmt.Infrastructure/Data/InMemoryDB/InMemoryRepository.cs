using System;
using InvoiceMgmt.ApplicationCore.Entities;
using InvoiceMgmt.ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InvoiceMgmt.Infrastructure.Data.InMemoryDB
{
    public class InMemoryRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly AppDbContext _dbContext;

        public InMemoryRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(TEntity item, CancellationToken cancellationToken = default)
        {
            await _dbContext.Set<TEntity>()
                            .AddAsync(item, cancellationToken);
        }

        public async Task<int> CountAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<TEntity>()
                                   .CountAsync(cancellationToken);
        }

        public async Task DeleteAsync(TEntity item, CancellationToken cancellationToken = default)
        {
            await Task.Run(() => _dbContext.Set<TEntity>().Remove(item), cancellationToken);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<TEntity>()
                                   .ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<TEntity>()
                                   .FirstOrDefaultAsync(i => i.Id == id, cancellationToken);
        }

        public async Task<int> SaveAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(TEntity item, CancellationToken cancellationToken = default)
        {
            await Task.Run(() => _dbContext.Set<TEntity>().Update(item), cancellationToken);
        }
    }
}

