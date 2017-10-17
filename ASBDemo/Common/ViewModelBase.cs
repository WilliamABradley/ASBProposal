using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Windows.UI.Core;

namespace ASBDemo.Common
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public ViewModelBase(CoreDispatcher Dispatcher)
        {
            this.Dispatcher = Dispatcher;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void UpdateProperty([CallerMemberName]string PropertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        protected async Task OnUIThreadAsync(Action action)
        {
            await DetermineExecutionAsync(action);
        }

        protected void OnUIThread(Action action)
        {
            DetermineExecution(action);
        }

        /// <summary>
        /// If it is unknown if a Dispatcher is attached, it will determine where to execute the action
        /// </summary>
        public async void DetermineExecution(Action action)
        {
            await DetermineExecutionAsync(action);
        }

        /// <summary>
        /// If it is unknown if a Dispatcher is attached, it will determine where to execute the action
        /// </summary>
        public async Task DetermineExecutionAsync(Action action)
        {
            if (Dispatcher != null) await VisualTools.OnUIThreadAsync(action);
            else action();
        }

        public CoreDispatcher Dispatcher;
    }
}