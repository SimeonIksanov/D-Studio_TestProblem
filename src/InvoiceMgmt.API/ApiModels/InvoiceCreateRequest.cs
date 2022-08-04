using System.ComponentModel.DataAnnotations;

namespace InvoiceMgmt.API.ApiModels;

public class InvoiceCreateRequest : InvoiceCreateChangeBase
{
    [Required, Range(1, uint.MaxValue)]
    public uint Number { get; set; }
}
