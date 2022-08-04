namespace InvoiceMgmt.ApplicationCore.Entities;

public enum PaymentMethod
{
    CreditCard = 0b_001,
    DebitCard = 0b_010,
    ECheck = 0b_100
}
