using ASBDemo.Controls;
using ASBDemo.Viewmodels;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ASBDemo.Views.Payments
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class OneOffPayment : Page
    {
        public OneOffPayment()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            SessionModel.Current.SetPageName("One-Off Payment");
            TopBar.Current.ShowAppBackButton(true);
            base.OnNavigatedTo(e);
        }
    }
}