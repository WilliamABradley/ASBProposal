using ASBDemo.Viewmodels;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ASBDemo.Views.Entry.Register
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class VerifyNumber : Page
    {
        private RegistrationModel Viewmodel { get; }
        public TaskCompletionSource<bool> Result = new TaskCompletionSource<bool>();

        public VerifyNumber(RegistrationModel Viewmodel)
        {
            this.InitializeComponent();
            this.Viewmodel = Viewmodel;
        }

        private void Continue_Click(object sender, RoutedEventArgs e)
        {
            Result.TrySetResult(true);
        }
    }
}