using ASBDemo.Models;

namespace ASBDemo.Viewmodels
{
    public class AccountHistoryModel
    {
        public AccountHistoryModel(AccountHistoryItem Model)
        {
            this.Model = Model;
        }

        public AccountHistoryItem Model { get; }

        public string Transaction
        {
            get { return Model.Provider.ToString(); }
        }

        public string Debit
        {
            get { return MoneyValue(Model.DebitAmount); }
        }

        public string Credit
        {
            get { return MoneyValue(Model.CreditAmount); }
        }

        public string Balance
        {
            get { return MoneyValue(Model.Balance); }
        }

        public string TransactionDate
        {
            get { return Model.TransferTime.ToString("yyyy/MM/dd hh:mm tt"); }
        }

        public string MoneyValue(decimal? value)
        {
            return value.HasValue ? $"${value.Value}" : "";
        }
    }
}