using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;

namespace ASBDemo.Models
{
    public class ShellCommand : LabelledCommand
    {
        public event EventHandler IconReplacementRequested;

        public IconElement Icon { get; set; }
        public List<IconElement> Icons { get; } = new List<IconElement>();

        public void ReplaceIcons(IconElement Icon)
        {
            this.Icon = Icon;
            IconReplacementRequested?.Invoke(this, null);
        }
    }

    public class ToggleShellCommand : ShellCommand
    {
        public bool Toggled { get; set; } = false;
    }
}