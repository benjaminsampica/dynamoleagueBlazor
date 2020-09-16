using System.Collections.Generic;
using System.Linq;

namespace Domain.Entities
{
    public class Team : BaseEntity
    {
        public string TeamKey { get; set; }
        public string TeamName { get; set; }
        public string TeamLogoUrl { get; set; }

        public ICollection<Player> Players { get; set; }

        public int CapSpace() => Players.Sum(p => p.ContractValue);
    }
}
