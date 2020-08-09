using Application.UnitTests.Common.AutoFixture;
using AutoFixture;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;

namespace Application.UnitTests.Common
{
    internal class DynamoLeagueContextFactory
    {
        public static DynamoLeagueDbContext Create()
        {
            var options = new DbContextOptionsBuilder<DynamoLeagueDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new DynamoLeagueDbContext(options);

            context.Database.EnsureCreated();

            context.Teams.Add(Utilities.GetFixture().Build<Team>().Without(e => e.Id).Create());

            context.Players.Add(
                Utilities.GetFixture().Build<Player>()
                .Without(e => e.Id)
                .With(e => e.TeamId, 1)
                .With(e => e.ContractLength, 3000)
                .Create()
            );

            context.SaveChanges();

            return context;
        }

        public static void Destroy(DynamoLeagueDbContext context)
        {
            context.Database.EnsureDeleted();

            context.Dispose();
        }
    }
}
