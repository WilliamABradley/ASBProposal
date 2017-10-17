using ASBDemo.Models.Transactions;
using System;

namespace ASBDemo.Models
{
    public class AccountHistoryItem
    {
        public ITransactionProvider Provider { get; set; }
        public DateTimeOffset TransferTime { get; set; }

        public decimal? DebitAmount { get; set; }
        public decimal? CreditAmount { get; set; }
        public decimal Balance { get; set; }
    }
}