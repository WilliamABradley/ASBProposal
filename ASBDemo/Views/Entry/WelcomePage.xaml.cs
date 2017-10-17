using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using ASBDemo.Viewmodels;
using ASBDemo.Views.Entry.Register;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ASBDemo.Views.Entry
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class WelcomePage : Page
    {
        private RegistrationModel Viewmodel { get; }

        public WelcomePage()
        {
            this.InitializeComponent();
            Viewmodel = new RegistrationModel(Dispatcher);
            Viewmodel.Registered += Viewmodel_Registered;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            SessionModel.Current.SetPageName("Registration");
            base.OnNavigatedTo(e);
        }

        private void Viewmodel_Registered(object sender, EventArgs e)
        {
            Window.Current.Content = new Registration(Viewmodel);
        }
    }
}