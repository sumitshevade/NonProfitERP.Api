namespace PublicData.WebClient.Shared.Models
{
    public partial class TransactionLogValueModel
    {
        public int Id { get; set; }
        public int TransactionLogId { get; set; }
        public string TableName { get; set; }
        public string PreviousValue { get; set; }
        public string NewValue { get; set; }
    }
}
