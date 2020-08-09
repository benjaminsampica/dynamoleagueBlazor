using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Persistence
{
    public class DynamoLeagueDbContext : DbContext, IDynamoLeagueDbContext
    {
        public DynamoLeagueDbContext(DbContextOptions<DynamoLeagueDbContext> options)
            : base(options)
        {
        }

        public DbSet<Bid> Bids { get; set; }
        public DbSet<Fine> Fines { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
