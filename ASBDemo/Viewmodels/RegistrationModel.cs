using ASBDemo.Common;
using System;
using System.Threading.Tasks;
using Windows.UI.Core;

namespace ASBDemo.Viewmodels
{
    public class RegistrationModel : ViewModelBase
    {
        public RegistrationModel(CoreDispatcher Dispatcher) : base(Dispatcher)
        {
        }

        public void AttemptRegistration()
        {
            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
            {
                VisualTools.ShowError("Please Enter both your Username and Password");
            }
            else
            {
                Task.Run(() => SessionModel.Current.API.GetUserToken(Username, Password)).ContinueOnUIThread(Dispatcher, task =>
                {
                    if (string.IsNullOrWhiteSpace(task.Result))
                    {
                        VisualTools.ShowError("The Username/Password was incorrect");
                    }
                    else
                    {
                        SessionModel.Current.DeviceRegistered(task.Result);
                        Registered?.Invoke(this, null);
                    }
                });
            }
        }

        public void SendNetcode()
        {
            SentNetcode = true;
            UpdateProperty(nameof(SentNetcode));
        }

        public Task<bool> VerifyNetCode()
        {
            return Task.FromResult(true);
        }

        public string Username { get; set; }
        public string Password { get; set; }

        public bool SentNetcode { get; private set; } = false;

        private string _NetCode;

        public string NetCode
        {
            get { return _NetCode; }
            set
            {
                _NetCode = value;
                UpdateProperty(nameof(IsNetCodeEntered));
            }
        }

        public bool IsNetCodeEntered { get { return NetCode?.Length == 8; } }

        public string PhoneNumber { get; set; }

        public event EventHandler Registered;
    }
}