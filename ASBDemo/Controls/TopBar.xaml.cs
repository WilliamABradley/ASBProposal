using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using ASBDemo.Common;
using Windows.UI.Core;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace ASBDemo.Controls
{
    public sealed partial class TopBar : UserControl
    {
        public static TopBar Current;

        public TopBar()
        {
            Current = this;
            this.InitializeComponent();
            VisualTools.SetToolbarChrome(TitleBar);
        }

        public void ShowAppBackButton(bool ShowBackButton)
        {
            VisualTools.OnUIThread(() =>
            {
                if (ShowBackButton)
                {
                    TitleBar.Padding = new Thickness(48, 0, 0, 0);
                    SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
                }
                else
                {
                    TitleBar.Padding = new Thickness(0);
                    SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
                }
            });
        }

        public string PageName
        {
            get { return (string)GetValue(PageNameProperty); }
            set { SetValue(PageNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PageName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PageNameProperty =
            DependencyProperty.Register(nameof(PageName), typeof(string), typeof(TopBar), new PropertyMetadata("ASB"));

        public bool IsToggleVisible
        {
            get { return (bool)GetValue(IsToggleVisibleProperty); }
            set { SetValue(IsToggleVisibleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsToggleVisible.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsToggleVisibleProperty =
            DependencyProperty.Register(nameof(IsToggleVisible), typeof(bool), typeof(TopBar), new PropertyMetadata(true));

        public bool IsToggleActive
        {
            get { return (bool)GetValue(IsToggleActiveProperty); }
            set { SetValue(IsToggleActiveProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsToggleActive.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsToggleActiveProperty =
            DependencyProperty.Register(nameof(IsToggleActive), typeof(bool), typeof(TopBar), new PropertyMetadata(false));
    }
}