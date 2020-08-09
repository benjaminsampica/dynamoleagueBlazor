using Application.Common.Interfaces;

namespace Application.Common.Models
{
    public abstract class PagedRequest : IPagedRequest
    {
        public PagedRequest(int skip, int take, string search = null) => (Skip, Take, Search) = (skip, take, search);

        public int Skip { get; }
        public int Take { get; }
        public string Search { get; }
    }
}
