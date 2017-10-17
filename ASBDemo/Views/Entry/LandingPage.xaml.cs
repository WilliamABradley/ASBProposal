using ASBDemo.Viewmodels;
using System;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ASBDemo.Views.Entry
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LandingPage : Page
    {
        public LandingPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            SessionModel.Current.SetPageName("Welcome back");
            base.OnNavigatedTo(e);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Payments.OneOffPayment));
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var accounts = await SessionModel.Current.API.GetAccounts(null);
            Frame.Navigate(typeof(AccountView.AccountBalance), accounts.First());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(WelcomePage));
        }
    }
}