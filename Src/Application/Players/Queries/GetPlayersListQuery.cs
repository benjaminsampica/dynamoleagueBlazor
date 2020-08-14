using Application.Common.Interfaces;
using Application.Common.Mappings;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Teams.Queries
{
    public class GetPlayersListQuery : IRequest<ReadOnlyCollection<PlayerListDto>>
    {
        internal int TeamId { get; set; }

        public GetPlayersListQuery(int teamId)
        {
            TeamId = teamId;
        }

        internal sealed class Handler : IRequestHandler<GetPlayersListQuery, ReadOnlyCollection<PlayerListDto>>
        {
            private readonly IDynamoLeagueDbContext _dbContext;
            private readonly IMapper _mapper;

            public Handler(IDynamoLeagueDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<ReadOnlyCollection<PlayerListDto>> Handle(GetPlayersListQuery request, CancellationToken cancellationToken = default)
            {
                return (await _dbContext.Players
                    .AsNoTracking()
                    .ProjectTo<PlayerListDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken))
                    .AsReadOnly();
            }
        }
    }

    public class PlayerListDto : IMapFrom<Player>
    {
        public int Id { get; set; }
        public int TeamId { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string TeamName { get; set; }
        public string ContractValue { get; set; }
        public int ContractLength { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Player, PlayerListDto>();
        }
    }
}
