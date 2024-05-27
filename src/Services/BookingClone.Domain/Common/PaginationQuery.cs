namespace BookingClone.Domain.Common;

public sealed class PaginationQuery
{
    public int PageNumber { get; init; }

    public int PageSize { get; init; }

    public PaginationQuery()
    {
        PageNumber = 1;
        PageSize = 10;
    }

    public PaginationQuery(int pageNumber, int pageSize)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
    }
}