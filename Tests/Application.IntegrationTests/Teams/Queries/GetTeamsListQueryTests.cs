using Application.Teams.Queries;
using Domain.Entities;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;
using Tynamix.ObjectFiller;

namespace Application.IntegrationTests.Players.Queries
{
    using static Testing;

    public class GetTeamsListQueryTests : TestBase
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
        }

        [Test]
        public async Task GivenOneTeam_WhenNoPlayerIsActive_ThenReturnOneTeamWithZeroCapSpace()
        {
            var fillerPlayer = new Filler<Player>();
            fillerPlayer.Setup()
                .IgnoreInheritance()
                .OnProperty(p => p.TeamId).Use(_teamId)
                .OnProperty(p => p.ContractLength).Use(DateTime.Today.Year - 1)
                .OnProperty(p => p.ContractValue).Use(100)
                .OnProperty(p => p.Bids).IgnoreIt()
                .OnProperty(p => p.Team).IgnoreIt();
            await AddAsync(fillerPlayer.Create());

            var query = new GetTeamsListQuery();

            var result = await SendAsync(query);

            result.Should().NotBeNull();
            result.Count.Should().Be(1);
            result.First().CapSpace.Should().Be(0);
        }

        [Test]
        public async Task GivenOneTeam_WhenOnePlayerIsActive_ThenReturnOneTeamWithNonZeroCapSpace()
        {
            var fillerPlayer = new Filler<Player>();
            fillerPlayer.Setup()
                .IgnoreInheritance()
                .OnProperty(p => p.TeamId).Use(_teamId)
                .OnProperty(p => p.ContractLength).Use(DateTime.Today.Year)
                .OnProperty(p => p.ContractValue).Use(100)
                .OnProperty(p => p.Bids).IgnoreIt()
                .OnProperty(p => p.Team).IgnoreIt();
            await AddAsync(fillerPlayer.Create());

            var query = new GetTeamsListQuery();

            var result = await SendAsync(query);

            result.Should().NotBeNull();
            result.Count.Should().Be(1);
            result.First().CapSpace.Should().NotBe(0);
        }
    }
}
