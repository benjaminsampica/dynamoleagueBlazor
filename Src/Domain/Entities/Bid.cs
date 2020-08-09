using System;

namespace Domain.Entities
{
    public class Bid : BaseEntity
    {
        private Bid() { }

        public Bid(int amount, int teamId, int playerId)
        {
            PlayerId = playerId;
            Amount = amount;
            TeamId = teamId;
            DateTime = DateTime.Now;
        }

        public int Amount { get; set; }
        public int PlayerId { get; set; }
        public int TeamId { get; set; }
        public DateTime DateTime { get; set; }

        public Team Team { get; set; }
        public Player Player { get; set; }
    }
}
