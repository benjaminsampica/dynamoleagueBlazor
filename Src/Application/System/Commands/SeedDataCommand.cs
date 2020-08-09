using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.System.Commands
{
    public class SeedDataCommand : IRequest<Unit>
    {
        public class Handler : IRequestHandler<SeedDataCommand, Unit>
        {
            private readonly IDynamoLeagueDbContext _dbContext;

            public Handler(IDynamoLeagueDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<Unit> Handle(SeedDataCommand request, CancellationToken cancellationToken)
            {
                var teams = new List<Team>
                {
                    new Team { TeamKey = "390.l.40360.t.1", TeamName = "Space Force", TeamLogoUrl = "https://yahoofantasysports-res.cloudinary.com/image/upload/t_s192sq/fantasy-logos/57182575954_a32e35.jpg" },
                    new Team { TeamKey = "390.l.40360.t.2", TeamName = "The Donald", TeamLogoUrl = "https://yahoofantasysports-res.cloudinary.com/image/upload/t_s192sq/fantasy-logos/57182575954_a32e35.jpg" },
                    new Team { TeamKey = "390.l.40360.t.3", TeamName = "Big Chief no Fart", TeamLogoUrl = "https://yahoofantasysports-res.cloudinary.com/image/upload/t_s192sq/fantasy-logos/57182575954_a32e35.jpg" },
                    new Team { TeamKey = "390.l.40360.t.4", TeamName = "Altoona Tunafish", TeamLogoUrl = "https://yahoofantasysports-res.cloudinary.com/image/upload/t_s192sq/fantasy-logos/57182575954_a32e35.jpg" },
                    new Team { TeamKey = "390.l.40360.t.5", TeamName = "Can't Fine This", TeamLogoUrl = "https://yahoofantasysports-res.cloudinary.com/image/upload/t_s192sq/fantasy-logos/57182575954_a32e35.jpg" },
                    new Team { TeamKey = "390.l.40360.t.6", TeamName = "Finkle Einhorn", TeamLogoUrl = "https://yahoofantasysports-res.cloudinary.com/image/upload/t_s192sq/fantasy-logos/57182575954_a32e35.jpg" },
                    new Team { TeamKey = "390.l.40360.t.7", TeamName = "J.J. Mafia", TeamLogoUrl = "https://yahoofantasysports-res.cloudinary.com/image/upload/t_s192sq/fantasy-logos/57182575954_a32e35.jpg" },
                    new Team { TeamKey = "390.l.40360.t.8", TeamName = "Natty Lite", TeamLogoUrl = "https://yahoofantasysports-res.cloudinary.com/image/upload/t_s192sq/fantasy-logos/57182575954_a32e35.jpg" },
                    new Team { TeamKey = "390.l.40360.t.9", TeamName = "Starts With a W", TeamLogoUrl = "https://yahoofantasysports-res.cloudinary.com/image/upload/t_s192sq/fantasy-logos/57182575954_a32e35.jpg" },
                    new Team { TeamKey = "390.l.40360.t.10", TeamName = "Magic SKOL Bus", TeamLogoUrl = "https://yahoofantasysports-res.cloudinary.com/image/upload/t_s192sq/fantasy-logos/57182575954_a32e35.jpg" },
                };
                _dbContext.Teams.AddRange(teams);
                await _dbContext.SaveChangesAsync(cancellationToken);

                for (int i = 1; i < 250; i++)
                {
                    var player = new Player
                    {
                        PlayerKey = "390.p.100001",
                        Name = "Atlanta",
                        Position = "DEF",
                        TeamId = new Random().Next(1, 10),
                        ContractLength = DateTime.Now.Year,
                        ContractValue = 1,
                        YearAcquired = DateTime.Now.Year,
                        HeadShot = "https://s.yimg.com/lq/i/us/sp/v/nfl/teams/1/50x50w/chi.gif",
                        Rostered = true
                    };

                    _dbContext.Players.Add(player);
                }

                await _dbContext.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
