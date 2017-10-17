using ASBDemo.Enums;

namespace ASBDemo.Models.Accounts
{
    public class BankAccount : IAccount
    {
        public ulong ID { get; set; }
        public string Name { get; set; }

        public decimal Balance { get; set; }
        public decimal AvailableBalance { get; set; }

        public AccountType Type { get; set; }
        public string AccountHolder { get; set; }

        public string FriendlyIdentifier { get { return ID.ToString(); } }
    }
}