using Common;
using System;

namespace Infrastructure.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime Now => DateTime.Now;
        public DateTime Today => DateTime.Today;
    }
}
