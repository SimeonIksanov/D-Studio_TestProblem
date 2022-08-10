using InvoiceMgmt.ApplicationCore.Entities;

namespace InvoiceMgmt.ApplicationCore.Specifications;

public class InvoiceSpecification : BaseSpecification<Invoice>
{
    public InvoiceSpecification()
    {
        Criteria = (b) => b.Amount > 10;
    }
}
