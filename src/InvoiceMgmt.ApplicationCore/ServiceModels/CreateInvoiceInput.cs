using InvoiceMgmt.ApplicationCore.Entities;

namespace InvoiceMgmt.API.ServiceModels;

public class CreateInvoiceInput
{
    public uint Number { get; set; }
    public Decimal Amount { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
}
