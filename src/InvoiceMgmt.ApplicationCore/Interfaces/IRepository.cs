using InvoiceMgmt.ApplicationCore.Entities;

namespace InvoiceMgmt.ApplicationCore.Interfaces;

public interface IRepository
{
    Task<IEnumerable<Invoice>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<Invoice> GetByIdAsync(int id, CancellationToken cancellationToken = default);

    Task AddAsync(Invoice item, CancellationToken cancellationToken = default);

    Task UpdateAsync(Invoice item, CancellationToken cancellationToken = default);

    Task DeleteAsync(Invoice item, CancellationToken cancellationToken = default);

    Task<int> CountAsync(CancellationToken cancellationToken = default);

    Task<int> SaveAsync(CancellationToken cancellationToken = default);
}
