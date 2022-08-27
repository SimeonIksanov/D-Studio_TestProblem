namespace InvoiceMgmt.ApplicationCore.Entities;

public class InvoiceQueryParameters : QueryStringParameters
{
    public DateTimeOffset CreatedAtAfter { get; set; } = DateTimeOffset.MinValue;
    public DateTimeOffset CreatedAtBefore { get; set; } = DateTimeOffset.MaxValue;

    public DateTimeOffset ChangedAtAfter { get; set; } = DateTimeOffset.MinValue;
    public DateTimeOffset ChangedAtBefore { get; set; } = DateTimeOffset.MaxValue;

    public int MinNumber { get; set; } = int.MinValue;
    public int MaxNumber { get; set; } = int.MaxValue;

    public decimal MinAmount { get; set; } = decimal.MinValue;
    public decimal MaxAmount { get; set; } = decimal.MaxValue;

    public int PaymentMethodMask { get; set; } = 0b_111;
    public int StateMask { get; set; } = 0b_111;

    public string SortBy { get; set; } = nameof(Invoice.Number);
    public string SortOrder { get; set; } = "Desc";
}
