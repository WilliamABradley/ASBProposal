using ASBDemo.Common;
using ASBDemo.Services;
using System;
using Windows.UI.Core;

namespace ASBDemo.Viewmodels
{
    public class SessionModel : ViewModelBase
    {
        public static SessionModel Current;

        public SessionModel(CoreDispatcher Dispatcher) : base(Dispatcher)
        {
            Current = this;

            if (true) // verification for Development mode
            {
                API = new DemoService();
            }
        }

        public void DeviceRegistered(string Token)
        {
            IsDeviceRegistered = Token != null;
            //store token
            OnUIThread(() =>
            {
                UpdateProperty(nameof(IsDeviceRegistered));
            });
        }

        public void Login()
        {
            IsDeviceLoggedIn = true;
            UpdateProperty(nameof(IsDeviceLoggedIn));
            LoggedIn?.Invoke(this, null);
        }

        public void SetPageName(string PageName)
        {
            this.PageName = PageName;
            UpdateProperty(nameof(PageName));
        }

        public bool IsDeviceRegistered { get; private set; } = true;
        public bool IsDeviceLoggedIn { get; private set; } = false;

        public string PageName { get; private set; }

        public IASBService API { get; }

        public event EventHandler LoggedIn;
    }
}