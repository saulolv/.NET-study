namespace minimal_api.Domain.Helpers;

public class Pagination<T>
{
    public int Page { get; set; }
    public int PageSize { get; set; }
    public int TotalItems { get; set; }
    public int TotalPages => (int)Math.Ceiling(TotalItems / (double)PageSize);
    public List<T> Items { get; set; } = new List<T>();
    
    public void Deconstruct(out List<T> items, out int totalItems)
    {
        items = Items;
        totalItems = TotalItems;
    }
}