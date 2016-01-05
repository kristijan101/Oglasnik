namespace Oglasnik.Common
{
    public interface IFilter
    {
        int PageNumber { get; }
        int PageSize { get; }
        string SearchString { get; }
    }
}