using InvoiceMgmt.ApplicationCore.Entities;
using InvoiceMgmt.ApplicationCore.Interfaces;

namespace InvoiceMgmt.Infrastructure.Data.InMemoryDB;

public class InvoiceRepository : GenericRepository<Invoice>, IInvoiceRepository
{
    public InvoiceRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}

