using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.Foundation.Metadata;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace ASBDemo.Common
{
    public static class VisualTools
    {
        public static Color AppAccent { get { return (Color)Application.Current.Resources["SystemAccentColor"]; } }

        public static async void ShowError(string message, bool Warn = false, bool cancellable = true)
        {
            await ShowErrorAsync(message, Warn, cancellable);
        }

        public static async Task<ContentDialogResult> ShowErrorAsync(string message, bool Warn = false, bool cancellable = true)
        {
            return await new ContentDialog { Title = Warn ? "Warning" : "Error", Content = message, PrimaryButtonText = "OK", SecondaryButtonText = Warn && cancellable ? "Cancel" : "" }.CreateContentDialogAsync(false);
        }

        public static async void OnUIThread(Action action)
        {
            await OnUIThreadAsync(action);
        }

        public static async Task OnUIThreadAsync(Action action)
        {
            var Dispatcher = CoreApplication.MainView.CoreWindow.Dispatcher;
            await OnUIThreadAsync(Dispatcher, action);
        }

        public static async void OnUIThread(CoreDispatcher dispatcher, Action action)
        {
            await OnUIThreadAsync(dispatcher, action);
        }

        public static async Task OnUIThreadAsync(CoreDispatcher dispatcher, Action action)
        {
            await dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => action());
        }

        public static void SetToolbarChrome(UIElement element)
        {
            ApplicationViewTitleBar formattableTitleBar = ApplicationView.GetForCurrentView().TitleBar;
            formattableTitleBar.ButtonBackgroundColor = Colors.Transparent;
            formattableTitleBar.ButtonInactiveBackgroundColor = Colors.Transparent;
            CoreApplication.GetCurrentView().TitleBar.ExtendViewIntoTitleBar = true;
            if (element != null) Window.Current.SetTitleBar(element);

            if (ApiInformation.IsTypePresent("Windows.UI.ViewManagement.StatusBar"))
            {
                StatusBar.GetForCurrentView().BackgroundColor = AppAccent;
                StatusBar.GetForCurrentView().BackgroundOpacity = 0.7;
                StatusBar.GetForCurrentView().ForegroundColor = Colors.White;
            }
        }

        /// <summary>
        /// Returns a list of Grid Elements in a control
        /// </summary>
        /// <param name="parent">Containing control</param>
        public static List<T> AllChildrenofType<T>(DependencyObject parent, bool deepscan = false)
        {
            var _List = new List<T>();
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                var _Child = VisualTreeHelper.GetChild(parent, i);
                if (_Child is T)
                {
                    _List.Add((T)(object)_Child);
                }
                _List.AddRange(AllChildrenofType<T>(_Child, deepscan));
            }
            if (deepscan)
            {
                if (parent is ContentPresenter presenter)
                {
                    var _Child = presenter.Content as DependencyObject;
                    if (_Child is T)
                    {
                        _List.Add((T)(object)_Child);
                    }
                    _List.AddRange(AllChildrenofType<T>(_Child, deepscan));
                }
                else if (parent is ContentControl control)
                {
                    var _Child = control.Content as DependencyObject;
                    if (_Child is T)
                    {
                        _List.Add((T)(object)_Child);
                    }
                    _List.AddRange(AllChildrenofType<T>(_Child, deepscan));
                }
            }
            return _List;
        }
    }
}