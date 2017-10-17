using System;

namespace ASBDemo.Models
{
    public class LabelledCommand
    {
        public LabelledCommand()
        {
        }

        public LabelledCommand(string Label, Action Action)
        {
            this.Label = Label;
            this.Action = Action;
        }

        public event EventHandler LabelReplacementRequested;

        public string Label { get; set; }
        public Action Action { get; set; }

        public void ReplaceLabel(string Label)
        {
            this.Label = Label;
            LabelReplacementRequested?.Invoke(this, null);
        }

        public void Activate()
        {
            Action();
        }

        public override string ToString()
        {
            return Label;
        }
    }
}