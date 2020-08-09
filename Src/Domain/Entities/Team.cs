using System.Collections.Generic;

namespace Domain.Entities
{
    public class Team : BaseEntity
    {
        public string TeamKey { get; set; }
        public string TeamName { get; set; }
        public string TeamLogoUrl { get; set; }

        public ICollection<Player> Players { get; private set; }
    }
}
