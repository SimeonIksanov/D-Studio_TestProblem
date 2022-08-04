using System.ComponentModel.DataAnnotations;
using InvoiceMgmt.ApplicationCore.Entities;

namespace InvoiceMgmt.API.ApiModels;

public abstract class InvoiceCreateChangeBase
{
    [Range(0, double.MaxValue)]
    public Decimal Amount { get; set; }

    [EnumDataType(typeof(PaymentMethod))]
    public PaymentMethod PaymentMethod { get; set; }
}
