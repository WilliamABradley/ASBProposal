using ASBDemo.Models;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ASBDemo.Controls
{
    public class BindableCommandBar : CommandBar
    {
        public BindableCommandBar()
        {
        }

        private bool HasItems = false;
        private bool Active = true;
        private bool locked = false;

        public bool RequestShowItems
        {
            get { return (bool)GetValue(RequestShowItemsProperty); }
            set { SetValue(RequestShowItemsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for RequestShowItems.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RequestShowItemsProperty =
            DependencyProperty.Register("RequestShowItems", typeof(bool), typeof(BindableCommandBar), new PropertyMetadata(true, OnRequest));

        private static void OnRequest(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var bar = d as BindableCommandBar;
            var value = (bool)e.NewValue;

            bar.Active = value;
            if (value) bar.TryShowItems();
            else bar.HideItems();
        }

        public void CreateCommandButton(ShellCommand command)
        {
            IconElement getIcon()
            {
                IconElement icon = null;
                if (command.Icon is SymbolIcon symbolicon) icon = new SymbolIcon { Symbol = symbolicon.Symbol };
                else if (command.Icon is FontIcon fonticon) icon = new FontIcon { FontFamily = fonticon.FontFamily, Glyph = fonticon.Glyph };

                command.Icons.Add(icon);

                return icon;
            }

            if (command is ToggleShellCommand togglecommand)
            {
                var button = new AppBarToggleButton()
                {
                    DataContext = command,
                    Label = command.Label,
                    Icon = getIcon()
                };
                button.Click += delegate { togglecommand.Toggled = button.IsChecked.Value; command.Action.Invoke(); };
                PrimaryCommands.Add(button);

                command.IconReplacementRequested += delegate
                {
                    command.Icons.Remove(button.Icon);
                    button.Icon = getIcon();
                };
                command.LabelReplacementRequested += delegate
                {
                    button.Label = command.Label;
                };
            }
            else
            {
                var button = new AppBarButton()
                {
                    DataContext = command,
                    Label = command.Label,
                    Icon = getIcon()
                };
                button.Click += delegate { command.Action?.Invoke(); };
                PrimaryCommands.Add(button);

                command.IconReplacementRequested += delegate
                {
                    command.Icons.Remove(button.Icon);
                    button.Icon = getIcon();
                };
                command.LabelReplacementRequested += delegate
                {
                    button.Label = command.Label;
                };
            }

            HasItems = true;
            TryShowItems();
        }

        public void TryShowItems(bool unlock = false)
        {
            locked = locked && !unlock;

            if (HasItems && Active && !locked)
            {
                Visibility = Visibility.Visible;
            }
        }

        public void HideItems(bool addLock = false)
        {
            locked = locked || addLock;
            Visibility = Visibility.Collapsed;
        }

        public void Clear()
        {
            HasItems = false;
            this.PrimaryCommands.Clear();
            HideItems();
        }
    }
}