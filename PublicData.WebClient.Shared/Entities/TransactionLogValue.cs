namespace PublicData.WebClient.Shared.Entities
{
    public partial class TransactionLogValue
    {
        public int TransactionLogId { get; set; }
        public string TableName { get; set; }
        public string PreviousValue { get; set; }
        public string NewValue { get; set; }
    }
}
