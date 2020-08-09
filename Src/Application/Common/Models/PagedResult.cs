using Application.Common.Interfaces;
using System.Collections.ObjectModel;

namespace Application.Common.Models
{
    public class PagedResult<T> : IPagedResult<T>
    {
        public int RecordCount { get; }
        public ReadOnlyCollection<T> Data { get; }
    }
}
