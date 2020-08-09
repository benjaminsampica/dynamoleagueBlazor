namespace Application.Common.Interfaces
{
    public interface IPagedRequest
    {
        public int Skip { get; }
        public int Take { get; }
        public string? Search { get; }
    }
}
