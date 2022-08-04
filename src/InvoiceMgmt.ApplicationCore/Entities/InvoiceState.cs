namespace InvoiceMgmt.ApplicationCore.Entities;

public enum InvoiceState
{
    New = 0b_0001,
    Paid = 0b_0010,
    Canceled = 0b_0100
}
