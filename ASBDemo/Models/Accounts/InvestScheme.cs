using ASBDemo.Enums;

namespace ASBDemo.Models.Accounts
{
    public class InvestScheme : IAccount
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }

        public InvestSchemeType Type { get; set; }

        public string FriendlyIdentifier { get { return ID; } }
    }
}