namespace Oglasnik.Common
{
    public interface IFilter
    {
        /// <summary>
        /// The string to be searched for.
        /// </summary>
        string SearchString { get; }
    }
}