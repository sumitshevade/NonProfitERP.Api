using System;

namespace PublicData.WebClient.Shared.Models
{
    public partial class TransactionLogModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string OperationType { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
