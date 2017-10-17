using ASBDemo.Models.Accounts;
using ASBDemo.Viewmodels;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ASBDemo.Views.AccountView
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AccountBalance : Page
    {
        public AccountBalanceModel Viewmodel { get; private set; }

        public AccountBalance()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var account = (BankAccount)e.Parameter;
            Shell.Current.SetPageName(account.Name);
            Viewmodel = new AccountBalanceModel(Dispatcher, account);
            SessionModel.Current.SetPageName(Viewmodel.PageName);
            base.OnNavigatedTo(e);
        }
    }
}