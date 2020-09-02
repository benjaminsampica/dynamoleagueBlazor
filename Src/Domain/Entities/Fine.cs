using System;

namespace Domain.Entities
{
    public class Fine : BaseEntity
    {
        private Fine() { }
        public Fine(decimal fineAmount, string fineReason, int playerId)
        {
            FineAmount = fineAmount;
            Status = false;
            FineDate = DateTime.Now;
            FineReason = fineReason;
            PlayerId = playerId;
        }

        public decimal FineAmount { get; set; }
        public bool Status { get; set; }
        public DateTime FineDate { get; set; }
        public string FineReason { get; set; }
        public int PlayerId { get; set; }

        public Player Player { get; set; }
    }
}
