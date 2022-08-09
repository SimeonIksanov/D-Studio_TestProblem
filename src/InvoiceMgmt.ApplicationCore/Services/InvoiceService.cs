using InvoiceMgmt.API.ServiceModels;
using InvoiceMgmt.ApplicationCore.Entities;
using InvoiceMgmt.ApplicationCore.Interfaces;

namespace InvoiceMgmt.ApplicationCore.Services;

public class InvoiceService : IInvoiceService
{
    private readonly IInvoiceRepository _repository;

    public InvoiceService(IInvoiceRepository repository)
    {
        _repository = repository;
    }

    public async Task ChangeAsync(Invoice invoice, CancellationToken cancellationToken = default)
    {
        await _repository.UpdateAsync(invoice, cancellationToken);
        await _repository.SaveAsync(cancellationToken);
    }

    public async Task<Invoice> CreateAsync(CreateInvoiceInput input, CancellationToken cancellationToken = default)
    {
        var invoice = new Invoice
        {
            Number = input.Number,
            Amount = input.Amount,
            PaymentMethod = input.PaymentMethod
        };
        await _repository.AddAsync(invoice, cancellationToken);
        await _repository.SaveAsync(cancellationToken);
        return invoice;
    }

    public async Task<Invoice> FindByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _repository.GetByIdAsync(id, cancellationToken);
    }

    public async Task<IEnumerable<Invoice>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _repository.GetAllAsync(cancellationToken);
    }
}

