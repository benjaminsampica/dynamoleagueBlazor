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
        private int _teamId;

        [SetUp]
        public async Task Initialize()
        {
            var fillerTeam = new Filler<Team>();
            fillerTeam.Setup()
                .IgnoreInheritance()
                .OnProperty(p => p.Players).IgnoreIt();
            var stubTeam = fillerTeam.Create();

            await AddAsync(stubTeam);
            _teamId = stubTeam.Id;

            var fillerPlayer = new Filler<Player>();
            fillerPlayer.Setup()
                .IgnoreInheritance()
                .OnProperty(p => p.TeamId).Use(stubTeam.Id)
                .OnProperty(p => p.Bids).IgnoreIt()
                .OnProperty(p => p.Team).IgnoreIt();

            await AddAsync(fillerPlayer.Create());
        }

        [Test]
        public async Task GivenMatchingTeamId_ShouldReturnOnePlayer()
        {
            var query = new GetPlayersListQuery(_teamId);

            var result = await SendAsync(query);

            result.Should().NotBeNull();
            result.Count.Should().Be(1);
        }

        [Test]
        public async Task GivenNonMatchingTeamId_ShouldReturnNoPlayers()
        {
            var query = new GetPlayersListQuery(int.MaxValue);

            var result = await SendAsync(query);

            result.Should().NotBeNull();
            result.Should().BeEmpty();
        }
    }
}
