using ASBDemo.Models.Accounts;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ASBDemo.Common;
using Windows.UI.Core;

namespace ASBDemo.Viewmodels
{
    public class AccountBalanceModel : ViewModelBase
    {
        public AccountBalanceModel(CoreDispatcher Dispatcher, BankAccount Account) : base(Dispatcher)
        {
            this.Account = Account;
            GetHistory();
        }

        public void GetHistory()
        {
            Task.Run(() => SessionModel.Current.API.GetAccountHistory(Account)).ContinueOnUIThread(Dispatcher, task =>
            {
                if (task.IsFaulted) return;
                foreach (var item in task.Result)
                {
                    History.Add(new AccountHistoryModel(item));
                }
            });
        }

        public BankAccount Account { get; }
        public ObservableCollection<AccountHistoryModel> History = new ObservableCollection<AccountHistoryModel>();

        public string PageName
        {
            get { return $"Balance for {Account.Name}"; }
        }
    }
}