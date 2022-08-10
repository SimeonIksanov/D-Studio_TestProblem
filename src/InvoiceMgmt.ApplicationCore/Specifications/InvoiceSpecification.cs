using InvoiceMgmt.ApplicationCore.Entities;

namespace InvoiceMgmt.ApplicationCore.Specifications;

public class InvoiceSpecification : BaseSpecification<Invoice>
{
    public InvoiceSpecification(InvoiceQueryParameters queryParameters)
    {
        Criteria = (b) =>
            b.Amount >= queryParameters.MinAmount
            && b.Amount <= queryParameters.MaxAmount

            && b.ChangedAt >= queryParameters.ChangedAtAfter
            && b.ChangedAt <= queryParameters.ChangedAtBefore

            && b.CreatedAt >= queryParameters.CreatedAtAfter
            && b.CreatedAt <= queryParameters.CreatedAtBefore

            && b.Number >= queryParameters.MinNumber
            && b.Number <= queryParameters.MaxNumber

            && ((int)b.PaymentMethod & queryParameters.PaymentMethodMask) != 0

            && ((int)b.State & queryParameters.StateMask) != 0;

        Page = queryParameters.Page;
        PageSize = queryParameters.PageSize;
    }
}
