using System.Collections.ObjectModel;

namespace Application.Common.Interfaces
{
    public interface IPagedResult<T>
    {
        int RecordCount { get; }
        ReadOnlyCollection<T> Data { get; }
    }
}
