using Application.Common.Interfaces;
using Application.Common.Mappings;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Teams.Queries
{
    public class GetTeamDetailsQuery : IRequest<TeamDetailsDto>
    {
        internal int TeamId { get; }

        public GetTeamDetailsQuery(int teamId)
        {
            TeamId = teamId;
        }

        internal sealed class Handler : IRequestHandler<GetTeamDetailsQuery, TeamDetailsDto>
        {
            private readonly IDynamoLeagueDbContext _dbContext;
            private readonly IMapper _mapper;
            private readonly ICurrentUserService _currentUserService;

            public Handler(IDynamoLeagueDbContext dbContext, IMapper mapper, ICurrentUserService currentUserService)
            {
                _dbContext = dbContext;
                _mapper = mapper;
                _currentUserService = currentUserService;
            }

            public async Task<TeamDetailsDto> Handle(GetTeamDetailsQuery request, CancellationToken cancellationToken = default)
            {
                var teamDto = await _dbContext.Teams
                    .AsNoTracking()
                    .Where(t => t.Id == request.TeamId)
                    .ProjectTo<TeamDetailsDto>(_mapper.ConfigurationProvider)
                    .SingleOrDefaultAsync(cancellationToken);

                if (teamDto != null)
                {
                    teamDto.IsCurrentUserTeam = await _currentUserService.GetTeamIdAsync() == request.TeamId;
                }

                return teamDto;
            }
        }
    }

    public class TeamDetailsDto : IMapFrom<Team>
    {
        public int Id { get; set; }
        public string TeamLogoUrl { get; set; }
        public string TeamName { get; set; }
        public int CapSpace { get; set; }
        public bool IsCurrentUserTeam { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Team, TeamDetailsDto>()
                .ForMember(p => p.CapSpace, mo => mo.MapFrom(t => t.Players.Sum(p => p.ContractValue)));
        }
    }
}
