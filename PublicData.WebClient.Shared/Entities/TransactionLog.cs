using System;

namespace PublicData.WebClient.Shared.Entities
{
    public partial class TransactionLog
    {
        public string UserId { get; set; }
        public string OperationType { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
