using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Player : BaseEntity
    {
        public string PlayerKey { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public int? ContractLength { get; set; }
        public int ContractValue { get; set; }
        public int YearAcquired { get; set; }
        public string HeadShot { get; set; }
        public bool Rostered { get; set; }
        public int? TeamId { get; set; }
        public DateTime? EndOfFreeAgency { get; set; }

        public Team Team { get; set; }
        public ICollection<Bid> Bids { get; private set; }
    }
}
