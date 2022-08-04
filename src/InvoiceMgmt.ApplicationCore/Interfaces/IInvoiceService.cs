using InvoiceMgmt.API.ServiceModels;
using InvoiceMgmt.ApplicationCore.Entities;

namespace InvoiceMgmt.ApplicationCore.Interfaces;

public interface IInvoiceService
{
    Task<Invoice> CreateAsync(CreateInvoiceInput input, CancellationToken cancellationToken = default);
    Task<IEnumerable<Invoice>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Invoice> FindByIdAsync(int id, CancellationToken cancellationToken = default);
    Task ChangeAsync(Invoice invoice, CancellationToken cancellationToken = default);
}
