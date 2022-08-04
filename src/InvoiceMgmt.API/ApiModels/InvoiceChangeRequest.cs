using System.ComponentModel.DataAnnotations;
using InvoiceMgmt.ApplicationCore.Entities;

namespace InvoiceMgmt.API.ApiModels;

public class InvoiceChangeRequest : InvoiceCreateChangeBase
{
    [Required, Range(1, int.MaxValue)]
    public int Id { get; set; }

    [EnumDataType(typeof(InvoiceState))]
    public InvoiceState State { get; set; }

}

