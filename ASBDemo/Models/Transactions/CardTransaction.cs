namespace ASBDemo.Models.Transactions
{
    public class CardTransaction : ITransactionProvider
    {
        public ulong CardID { get; set; }
        public string Retailer { get; set; }
        public string Location { get; set; }

        public override string ToString()
        {
            return $"CARD {CardID}\n{Retailer}\n{Location}";
        }
    }
}