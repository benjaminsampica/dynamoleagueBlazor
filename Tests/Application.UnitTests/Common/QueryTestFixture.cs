using Application.Common.Mappings;
using AutoMapper;
using Common;
using Moq;
using Persistence;
using System;
using Xunit;

namespace Application.UnitTests.Common
{
    public class QueryTestFixture : IDisposable
    {
        public DynamoLeagueDbContext Context { get; }
        public IMapper Mapper { get; }
        public IDateTimeProvider DateTime { get; }

        public QueryTestFixture()
        {
            Context = DynamoLeagueContextFactory.Create();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            Mapper = configurationProvider.CreateMapper();

            var mockDateTimeProvider = new Mock<IDateTimeProvider>();
            mockDateTimeProvider.Setup(m => m.Now).Returns(new DateTime(3000, 1, 1, 0, 0, 0));
            mockDateTimeProvider.Setup(m => m.Today).Returns(new DateTime(3000, 1, 1));
            DateTime = mockDateTimeProvider.Object;
        }

        public void Dispose()
        {
            DynamoLeagueContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}
