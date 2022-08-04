namespace InvoiceMgmt.ApplicationCore.Entities;

public sealed class Invoice : BaseEntity
{
    private decimal _amount;
    private PaymentMethod _paymentMethod;
    private InvoiceState _state;

    public Invoice()
    {
        CreatedAt = DateTimeOffset.Now;
        ChangedAt = DateTimeOffset.Now;
        State = InvoiceState.New;
    }

    public uint Number { get; init; }
    public DateTimeOffset CreatedAt { get; private set; }
    public DateTimeOffset ChangedAt { get; private set; }
    public InvoiceState State
    {
        get => _state;
        set
        {
            if (_state != value)
            {
                _state = value;
                OnChange();
            }
        }
    }
    public decimal Amount
    {
        get => _amount;
        set
        {
            if (_amount != value)
            {
                _amount = value;
                OnChange();
            }
        }
    }
    public PaymentMethod PaymentMethod
    {
        get => _paymentMethod;
        set
        {
            if (_paymentMethod != value)
            {
                _paymentMethod = value;
                OnChange();
            }
        }
    }

    private void OnChange()
    {
        ChangedAt = DateTimeOffset.Now;
    }
}

