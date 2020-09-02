using System;

namespace Common
{
    public interface IDateTimeService
    {
        DateTime Now { get; }
        DateTime Today { get; }
    }
}
