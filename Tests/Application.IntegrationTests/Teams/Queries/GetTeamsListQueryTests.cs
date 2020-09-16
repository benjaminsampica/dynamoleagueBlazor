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
        [SetUp]
        public async Task Initialize()
        {
            var fillerTeam = new Filler<Team>();
            fillerTeam.Setup()
                .IgnoreInheritance()
                .OnProperty(p => p.Players).IgnoreIt();
            var stubTeam = fillerTeam.Create();

            await AddAsync(stubTeam);

            var fillerPlayer = new Filler<Player>();
            fillerPlayer.Setup()
                .IgnoreInheritance()
                .OnProperty(p => p.TeamId).Use(stubTeam.Id)
                .OnProperty(p => p.ContractLength).Use(DateTime.Today.Year - 1)
                .OnProperty(p => p.ContractValue).Use(100)
                .OnProperty(p => p.Bids).IgnoreIt()
                .OnProperty(p => p.Team).IgnoreIt();

            await AddAsync(fillerPlayer.Create());
        }

        [Test]
        public async Task GivenOneTeam_WhenNoPlayerIsActive_ThenReturnOneTeamWithZeroCapSpace()
        {
            var query = new GetTeamsListQuery();

            var result = await SendAsync(query);

            result.Should().NotBeNull();
            result.Count.Should().Be(1);
            result.First().CapSpace.Should().Be(0);
        }
    }
}
