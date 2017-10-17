namespace ASBDemo.Models.Transactions
{
    public class TransferTransaction : ITransactionProvider
    {
        public string SenderName { get; set; }
        public string SenderID { get; set; }
        public string Particulars { get; set; }

        public override string ToString()
        {
            return $"TFR FROM {SenderName}\n{Particulars}";
        }
    }
}