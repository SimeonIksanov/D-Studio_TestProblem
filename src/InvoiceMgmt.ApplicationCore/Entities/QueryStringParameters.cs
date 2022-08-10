namespace InvoiceMgmt.ApplicationCore.Entities;

public abstract class QueryStringParameters
{
    const int MAX_PAGE_SIZE = 50;

    private int _pageSize = 10;
    private int _page = 1;

    public int Page
    {
        get => _page;
        set => _page = value < 1 ? 1 : value;
    }
    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = value switch
        {
            var x when x > 0 && x <= MAX_PAGE_SIZE => value,
            _ => _pageSize
        };
    }
}
