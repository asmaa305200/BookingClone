namespace BookingClone.Domain.Common;

public sealed class PagedList<T>
{
    public List<T> Data { get; set; }

    public PagedList()
    {
    }

    public PagedList(IEnumerable<T> items, int count, int pageNumber, int pageSize)
    {
        PageNumber = pageNumber;
        TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        Data = items as List<T> ?? new List<T>(items);
    }

    public int PageNumber { get; set; }

    public int TotalPages { get; set; }

    public bool IsFirstPage => PageNumber == 1;

    public bool IsLastPage => PageNumber == TotalPages;

    public int PageSize => Data.Count;

    public T this[int index] => Data[index];
}