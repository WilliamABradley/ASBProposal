using ASBDemo.Enums;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;

namespace ASBDemo.Common.Triggers
{
    public class IsTitleBarRequiredTrigger : StateTriggerBase
    {
        private bool IsRequired { get; set; }

        public IsTitleBarRequiredTrigger()
        {
            if (!Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            {
                ApplicationView view = ApplicationView.GetForCurrentView();

                IsRequired = !view.IsFullScreenMode && AppInformation.DeviceType == DeviceType.Desktop;
                SetActive(IsRequired);

                Window.Current.SizeChanged += CurrentWindow_SizeChanged;
            }
        }

        private void CurrentWindow_SizeChanged(object sender, Windows.UI.Core.WindowSizeChangedEventArgs e)
        {
            ApplicationView view = ApplicationView.GetForCurrentView();
            IsRequired = !view.IsFullScreenMode && AppInformation.DeviceType == DeviceType.Desktop && UIViewSettings.GetForCurrentView().UserInteractionMode == UserInteractionMode.Mouse;
            SetActive(IsRequired);
        }
    }
}