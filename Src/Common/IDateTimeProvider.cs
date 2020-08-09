using System;

namespace Common
{
    public interface IDateTimeProvider
    {
        DateTime Now { get; }
        DateTime Today { get; }
    }
}
