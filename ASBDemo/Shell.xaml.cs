using ASBDemo.Models;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using ASBDemo.Views.Entry;
using ASBDemo.Views;
using ASBDemo.Viewmodels;
using Windows.UI.Core;
using ASBDemo.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ASBDemo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Shell : Page
    {
        public static Shell Current;

        private object _LayoutParent;
        public object LayoutParent { get { return _LayoutParent ?? Parent; } set { _LayoutParent = value; } }

        private string PageName { get { return Titlebar.PageName; } set { Titlebar.PageName = value; } }

        public Shell SetPageName(string pagename, bool useCaps = true)
        {
            if (useCaps) PageName = pagename.ToUpper(); else { PageName = pagename; }
            return this;
        }

        public Frame ContentFrame { get { return MainFrame; } }

        public SessionModel Session { get; }

        private Type LoginPage { get { return Session.IsDeviceRegistered ? typeof(LandingPage) : typeof(WelcomePage); } }

        public Shell()
        {
            Current = this;

            this.InitializeComponent();
            Session = new SessionModel(Dispatcher);
            Session.LoggedIn += Session_LoggedIn;

            SystemNavigationManager.GetForCurrentView().BackRequested += Shell_BackRequested;

            MainFrame.Navigate(LoginPage);
        }

        public Shell AddCommand(ShellCommand command)
        {
            ShellCommands.CreateCommandButton(command);
            MobileShellCommands.CreateCommandButton(command);
            return this;
        }

        private void Shell_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (!e.Handled)
            {
                if (ContentFrame.CanGoBack) { if (ContentFrame.BackStackDepth == 1) { TopBar.Current.ShowAppBackButton(false); } ContentFrame.GoBack(); e.Handled = true; }
            }
        }

        private void Session_LoggedIn(object sender, EventArgs e)
        {
            TopPanel.Children.Remove(Login);
            //add logged in items
            MainFrame.Navigate(typeof(Balances));
        }

        private void MainFrame_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            if (ContentFrame.Content != null)
            {
                ShellCommands.Clear();
                MobileShellCommands.Clear();
            }
        }

        public void HideCommandBars(bool Hide)
        {
            if (Hide)
            {
                ShellCommands.HideItems(addLock: true);
                MobileShellCommands.HideItems(addLock: true);
            }
            else
            {
                ShellCommands.TryShowItems(unlock: true);
                MobileShellCommands.TryShowItems(unlock: true);
            }
        }

        private void MenuItem_Clicked(object sender, RoutedEventArgs e)
        {
            if (sender == Login) MainFrame.Navigate(LoginPage);
            if (sender == FindUs) MainFrame.Navigate(typeof(FindUs));
        }
    }
}