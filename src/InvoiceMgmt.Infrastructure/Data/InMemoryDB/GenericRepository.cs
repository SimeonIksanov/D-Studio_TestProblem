using System;
using InvoiceMgmt.ApplicationCore.Entities;
using InvoiceMgmt.ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InvoiceMgmt.Infrastructure.Data.InMemoryDB;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
{
    private readonly AppDbContext _dbContext;

    public GenericRepository(AppDbContext dbContext)
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

    public async Task<IEnumerable<TEntity>> FindAsync(ISpecification<TEntity> specification = null, CancellationToken cancellationToken = default)
    {
        var query = ProcessSpec(_dbContext.Set<TEntity>().AsQueryable(), specification);
        return await query.ToListAsync(cancellationToken);
    }

    //public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    //{
    //    return await _dbContext.Set<TEntity>()
    //                           .ToListAsync();
    //}

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

    protected virtual IQueryable<TEntity> ProcessSpec(IQueryable<TEntity> query, ISpecification<TEntity> spec)
    {
        if (spec.Criteria != null)
            query = query.Where(spec.Criteria);
        return query.Skip((spec.Page - 1) * spec.Page).Take(spec.PageSize);
    }
}

