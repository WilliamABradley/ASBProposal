using ASBDemo.Common;
using ASBDemo.Viewmodels;
using System;
using System.Linq;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ASBDemo.Views.Entry.Register
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Registration : Page
    {
        private RegistrationModel Viewmodel { get; }

        public Registration(RegistrationModel Viewmodel)
        {
            this.InitializeComponent();

            this.Viewmodel = Viewmodel;
            Begin();
        }

        public async void Begin()
        {
            SetActivePage();
            var netcodeValidator = new NetcodeValidate(Viewmodel);
            RegistrationViewer.Content = netcodeValidator;
            var netcodeResult = await netcodeValidator.Result.Task;
            if (netcodeResult) ; //Store netcode

            SetActivePage();
            var VerifyNumber = new VerifyNumber(Viewmodel);
            RegistrationViewer.Content = VerifyNumber;
            await VerifyNumber.Result.Task;

            SetActivePage();
            var DefaultAccount = new DefaultAccount(Viewmodel);
            RegistrationViewer.Content = DefaultAccount;
            await DefaultAccount.Result.Task;

            SetActivePage();
            var SSO = new CreateSingleSignOn(Viewmodel);
            RegistrationViewer.Content = SSO;
            await SSO.Result.Task;

            Window.Current.Content = Shell.Current;
            Shell.Current.ContentFrame.Navigate(typeof(LandingPage));
        }

        private int ActivePage = 0;

        private void SetActivePage()
        {
            for (int i = 0; i < 5; i++)
            {
                var element = ElementalViewer.Children.ElementAt(i) as Ellipse;
                if (i <= ActivePage) element.Fill = new SolidColorBrush(VisualTools.AppAccent);
                else element.Fill = new SolidColorBrush(Colors.Gray);
            }
            ActivePage++;
        }
    }
}