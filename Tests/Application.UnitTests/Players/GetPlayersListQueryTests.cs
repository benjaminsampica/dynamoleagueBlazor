using Application.Teams.Queries;
using Application.UnitTests.Common;
using AutoMapper;
using FluentAssertions;
using Persistence;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.Teams.Queries
{
    [Collection("QueryCollection")]
    public class GetPlayersListQueryTests
    {
        private readonly DynamoLeagueDbContext _context;
        private readonly IMapper _mapper;

        public GetPlayersListQueryTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task Handler_OneActivePlayer_ReturnsCountOfOne()
        {
            var sut = new GetPlayersListQuery.Handler(_context, _mapper);

            var result = await sut.Handle(new GetPlayersListQuery(1));

            result.Should().HaveCount(1);
            result.Should().BeOfType<ReadOnlyCollection<TeamListDto>>();
        }
    }
}
