using Application.Teams.Queries;
using Domain.Entities;
using FluentAssertions;
using NUnit.Framework;
using System.Threading.Tasks;
using Tynamix.ObjectFiller;

namespace Application.IntegrationTests.Players.Queries
{
    using static Testing;

    public class GetPlayersListQueryTests : TestBase
    {
        [Test]
        public async Task GivenTeamIdOfOne_ShouldReturnOnePlayer()
        {
            var teamId = 1;
            var fakePlayer = new Filler<Player>();
            fakePlayer.Setup()
                .OnProperty(p => p.TeamId).Use(teamId);

            await AddAsync(fakePlayer.Create());

            var query = new GetPlayersListQuery(teamId);

            var result = await SendAsync(query);

            result.Should().NotBeNull();
            result.Count.Should().Be(1);
        }

        [Test]
        public async Task GivenTeamIdOfOne_ShouldReturnNoPlayers()
        {
            var teamId = 2;
            var fakePlayer = new Filler<Player>();
            fakePlayer.Setup()
                .OnProperty(p => p.TeamId).Use(teamId);

            await AddAsync(fakePlayer.Create());

            var query = new GetPlayersListQuery(1);

            var result = await SendAsync(query);

            result.Should().NotBeNull();
            result.Should().BeEmpty();
        }
    }
}
