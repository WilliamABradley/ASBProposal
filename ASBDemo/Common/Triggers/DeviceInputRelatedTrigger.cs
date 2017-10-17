using ASBDemo.Enums;
using System;
using System.Linq;
using Windows.Foundation.Metadata;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;

namespace ASBDemo.Common.Triggers
{
    public class DeviceInputRelatedTrigger : StateTriggerBase
    {
        public DeviceInputRelatedTrigger()
        {
            if (!Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            {
                if (ApiInformation.IsTypePresent("Windows.Gaming.Input.UINavigationController"))
                {
                    isControllerActive = Windows.Gaming.Input.UINavigationController.UINavigationControllers.Any();
                    if (AppInformation.DeviceType != DeviceType.Xbox)
                    {
                        Windows.Gaming.Input.UINavigationController.UINavigationControllerAdded += UINavigationController_UINavigationControllerManipulated;
                        Windows.Gaming.Input.UINavigationController.UINavigationControllerRemoved += UINavigationController_UINavigationControllerManipulated;
                    }
                    if (AppInformation.DeviceType == DeviceType.Mobile)
                    {
                        CoreWindow.GetForCurrentThread().SizeChanged += ScreenSizeChanged;
                    }
                }
            }
        }

        private async void ScreenSizeChanged(CoreWindow sender, WindowSizeChangedEventArgs args)
        { var result = UIViewSettings.GetForCurrentView().UserInteractionMode == UserInteractionMode.Mouse; if (result != isInDesktopExperience) { isInDesktopExperience = result; await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => { DeviceFamily = DeviceFamily; }); } }

        private static bool isControllerActive = false;
        private static bool isInDesktopExperience = UIViewSettings.GetForCurrentView().UserInteractionMode == UserInteractionMode.Mouse;

        private async void UINavigationController_UINavigationControllerManipulated(object sender, Windows.Gaming.Input.UINavigationController e)
        { var result = Windows.Gaming.Input.UINavigationController.UINavigationControllers.Any(); if (result != isControllerActive) { isControllerActive = result; await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => { DeviceFamily = DeviceFamily; }); } }

        private DeviceType _currentDeviceFamily, _queriedDeviceFamily;

        public static DeviceType getCurrentInputType(bool internalcode = false)
        {
            if (!internalcode)
            {
                if (ApiInformation.IsTypePresent("Windows.Gaming.Input.UINavigationController"))
                {
                    isControllerActive = Windows.Gaming.Input.UINavigationController.UINavigationControllers.Any();
                }
            }

            var inputFamily = AppInformation.DeviceType;
            if (isControllerActive)
            {
                inputFamily = DeviceType.Xbox;
            }
            if (AppInformation.DeviceType == DeviceType.Mobile && isInDesktopExperience)
            {
                inputFamily = DeviceType.Desktop;
            }
            return inputFamily;
        }

        public bool Invert { get; set; } = false;

        public DeviceType DeviceFamily
        {
            get
            {
                return _queriedDeviceFamily;
            }

            set
            {
                if (!Windows.ApplicationModel.DesignMode.DesignModeEnabled)
                {
                    _queriedDeviceFamily = value;
                    _currentDeviceFamily = getCurrentInputType();

                    bool result = false;
                    if (!Invert) result = _queriedDeviceFamily == _currentDeviceFamily;
                    else result = _queriedDeviceFamily != _currentDeviceFamily;

                    SetActive(result);
                }
            }
        }
    }
}