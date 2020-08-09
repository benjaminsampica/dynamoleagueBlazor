using Application.Teams.Queries;
using Application.UnitTests.Common;
using AutoMapper;
using Common;
using FluentAssertions;
using Persistence;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.Teams.Queries
{
    [Collection("QueryCollection")]
    public class GetTeamsListQueryTests
    {
        private readonly DynamoLeagueDbContext _context;
        private readonly IMapper _mapper;
        private readonly IDateTimeProvider _dateTime;

        public GetTeamsListQueryTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
            _dateTime = fixture.DateTime;
        }

        [Fact]
        public async Task Handler_OneActivePlayer_ReturnsCountOfOne()
        {
            var sut = new GetTeamsListQuery.Handler(_context, _mapper, _dateTime);

            var result = await sut.Handle(new GetTeamsListQuery());

            result.Should().HaveCount(1);
            result.Should().BeOfType<ReadOnlyCollection<TeamListDto>>();
        }
    }
}
