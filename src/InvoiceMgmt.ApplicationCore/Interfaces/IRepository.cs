﻿using InvoiceMgmt.ApplicationCore.Entities;

namespace InvoiceMgmt.ApplicationCore.Interfaces;

public interface IRepository<TEntity> where TEntity : BaseEntity
{
    Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<TEntity> GetByIdAsync(int id, CancellationToken cancellationToken = default);

    Task AddAsync(TEntity item, CancellationToken cancellationToken = default);

    Task UpdateAsync(TEntity item, CancellationToken cancellationToken = default);

    Task DeleteAsync(TEntity item, CancellationToken cancellationToken = default);

    Task<int> CountAsync(CancellationToken cancellationToken = default);

    Task<int> SaveAsync(CancellationToken cancellationToken = default);
}
