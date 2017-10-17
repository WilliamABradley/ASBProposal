using ASBDemo.Common;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

namespace ASBDemo.Controls
{
    public sealed partial class ShellButton : UserControl
    {
        public ShellButton()
        {
            this.InitializeComponent();
        }

        public Binding _TextBinding { get; set; }

        public Binding TextBinding
        {
            get { return _TextBinding; }
            set
            {
                _TextBinding = value;
                Text = (string)Extensions.EvalBinding(value);
            }
        }

        private string _Text = "";

        public string Text
        {
            get { return _Text; }
            set
            {
                _Text = value;
                Bindings.Update();
            }
        }

        private string _Glyph = "";

        public string Glyph
        {
            get { return _Glyph; }
            set
            {
                _Glyph = value;
                Bindings.Update();
            }
        }

        private bool _ButtonActivated = false;

        public bool ButtonActivated
        {
            get
            {
                return _ButtonActivated;
            }
            set
            {
                var activate = value && !IsDialogOpener;
                if (activate)
                {
                    var buttons = VisualTools.AllChildrenofType<ShellButton>(Parent.GetBaseParent());
                    foreach (var button in buttons) if (button != this) button.ButtonActivated = false;

                    SelectedIndicator = true;
                }
                else SelectedIndicator = false;
                _ButtonActivated = value;
                Bindings.Update();
            }
        }

        public bool IsDialogOpener { get; set; } = false;

        private bool _SelectedIndicator = false;

        public bool SelectedIndicator
        {
            get { return _SelectedIndicator; }
            set
            {
                _SelectedIndicator = value;
                Bindings.Update();
            }
        }

        private bool _beginbutton = false;

        public bool BeginButton
        {
            get { return _beginbutton; }
            set
            {
                var beginbutton = value;
                if (beginbutton)
                {
                    SelectedIndicator = true;
                }
                _beginbutton = value;
                Bindings.Update();
            }
        }

        public event RoutedEventHandler Click;

        private void ShellButton_Clicked(object sender, RoutedEventArgs e)
        {
            ButtonActivated = true;
            Click?.Invoke(this, e);
        }
    }
}