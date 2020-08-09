using Persistence;
using System;

namespace Application.UnitTests.Common
{
    internal class CommandTestBase : IDisposable
    {
        protected readonly DynamoLeagueDbContext _context;

        public CommandTestBase()
        {
            _context = DynamoLeagueContextFactory.Create();
        }

        public void Dispose()
        {
            DynamoLeagueContextFactory.Destroy(_context);
        }
    }
}
