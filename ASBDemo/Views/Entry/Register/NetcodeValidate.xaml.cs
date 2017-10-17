using ASBDemo.Viewmodels;
using System;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ASBDemo.Views.Entry.Register
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NetcodeValidate : Page
    {
        private RegistrationModel Viewmodel { get; }
        public TaskCompletionSource<bool> Result { get; } = new TaskCompletionSource<bool>();

        public NetcodeValidate(RegistrationModel Viewmodel)
        {
            this.InitializeComponent();
            this.Viewmodel = Viewmodel;
        }

        private bool ValidResult { get; set; } = false;

        private void Later_Click(object sender, RoutedEventArgs e)
        {
            Result.TrySetResult(false);
        }

        private void NetCodeChanged(object sender, TextChangedEventArgs e)
        {
            Viewmodel.NetCode = NetCode.Text;
        }

        private async void Continue_Click(object sender, RoutedEventArgs e)
        {
            if (await Viewmodel.VerifyNetCode())
            {
                ValidResult = true;
                Result.TrySetResult(true);
            }
        }

        private void NetCodeSend_Click(object sender, RoutedEventArgs e)
        {
            NetCodeSend.Content = "Re-Send NetCode";
            Viewmodel.SendNetcode();
        }
    }
}