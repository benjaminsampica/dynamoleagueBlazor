using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IDynamoLeagueDbContext
    {
        DbSet<Bid> Bids { get; set; }
        DbSet<Fine> Fines { get; set; }
        DbSet<Player> Players { get; set; }
        DbSet<Team> Teams { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
