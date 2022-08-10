using InvoiceMgmt.ApplicationCore.Entities;
using InvoiceMgmt.ApplicationCore.Interfaces;

namespace InvoiceMgmt.Infrastructure.Data.InMemoryDB;

public class InvoiceRepository : GenericRepository<Invoice>, IInvoiceRepository
{
    public InvoiceRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    protected override IQueryable<Invoice> ProcessSpec(IQueryable<Invoice> query, ISpecification<Invoice> spec)
    {
        return spec.Criteria == null
            ? base.ProcessSpec(query, spec)
            : base.ProcessSpec(query.Where(spec.Criteria), spec);
    }
}

