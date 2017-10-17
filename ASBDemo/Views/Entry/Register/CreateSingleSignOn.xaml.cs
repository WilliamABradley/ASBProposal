using ASBDemo.Viewmodels;
using System;
using System.Threading.Tasks;
using Windows.Security.Credentials;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ASBDemo.Views.Entry.Register
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CreateSingleSignOn : Page
    {
        private RegistrationModel Viewmodel { get; }
        public TaskCompletionSource<bool> Result = new TaskCompletionSource<bool>();

        public CreateSingleSignOn(RegistrationModel Viewmodel)
        {
            this.InitializeComponent();
            this.Viewmodel = Viewmodel;
        }

        private async void Hello_Click(object sender, RoutedEventArgs e)
        {
            var keyCredentialAvailable = await KeyCredentialManager.IsSupportedAsync();
            var result = await KeyCredentialManager.RequestCreateAsync(Viewmodel.Username, KeyCredentialCreationOption.ReplaceExisting);
            //return public key, Attestation and Username to ASB for backend storage. Visit: https://docs.microsoft.com/en-us/windows/uwp/security/microsoft-passport for more info
            Result.TrySetResult(true);
        }

        private void Skip_Click(object sender, RoutedEventArgs e)
        {
            Result.TrySetResult(false);
        }
    }
}