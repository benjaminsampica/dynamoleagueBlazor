using Application.Common.Interfaces;
using Application.Common.Mappings;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Common;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Teams.Queries
{
    public class GetTeamsListQuery : IRequest<ReadOnlyCollection<TeamListDto>>
    {
        internal sealed class Handler : IRequestHandler<GetTeamsListQuery, ReadOnlyCollection<TeamListDto>>
        {
            private readonly IDynamoLeagueDbContext _dbContext;
            private readonly IMapper _mapper;
            private readonly IDateTimeProvider _dateTimeProvider;

            public Handler(IDynamoLeagueDbContext dbContext, IMapper mapper, IDateTimeProvider dateTimeProvider)
            {
                _dbContext = dbContext;
                _mapper = mapper;
                _dateTimeProvider = dateTimeProvider;
            }

            public async Task<ReadOnlyCollection<TeamListDto>> Handle(GetTeamsListQuery request, CancellationToken cancellationToken = default)
            {
                return (await _dbContext.Teams
                    .Include(p => p.Players)
                    .Where(t => t.Players.Any(p => p.ContractLength >= _dateTimeProvider.Now.Year))
                    .AsNoTracking()
                    .ProjectTo<TeamListDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken))
                    .AsReadOnly();
            }
        }
    }

    public class TeamListDto : IMapFrom<Team>
    {
        public int Id { get; set; }
        public string TeamLogoUrl { get; set; }
        public string TeamName { get; set; }
        public int PlayerCount { get; set; }
        public int CapSpace { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Team, TeamListDto>()
                .ForMember(p => p.PlayerCount, mo => mo.MapFrom(t => t.Players.Count))
                .ForMember(p => p.CapSpace, mo => mo.MapFrom(t => t.Players.Sum(p => p.ContractValue)));
        }
    }
}
