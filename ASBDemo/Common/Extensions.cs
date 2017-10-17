using System;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace ASBDemo.Common
{
    public static class Extensions
    {
        public static async void ContinueWith(this Task Task, Action action)
        {
            await Task.ContinueWith(task => action());
        }

        public static async void ContinueOnUIThread(this Task Task, CoreDispatcher Dispatcher, Action action)
        {
            await ContinueOnUIThreadAsync(Task, Dispatcher, action);
        }

        public static async void ContinueOnUIThread(this Task Task, CoreDispatcher Dispatcher, Action<Task> action)
        {
            await ContinueOnUIThreadAsync(Task, Dispatcher, action);
        }

        public static async void ContinueOnUIThread<T>(this Task<T> Task, CoreDispatcher Dispatcher, Action<Task<T>> action)
        {
            await ContinueOnUIThreadAsync(Task, Dispatcher, action);
        }

        public static async Task ContinueOnUIThreadAsync(this Task Task, CoreDispatcher Dispatcher, Action<Task> action)
        {
            await ContinueOnUIThreadAsync(Task, Dispatcher, () => action(Task));
        }

        public static async Task ContinueOnUIThreadAsync<T>(this Task<T> Task, CoreDispatcher Dispatcher, Action<Task<T>> action)
        {
            await ContinueOnUIThreadAsync(Task, Dispatcher, () => action(Task));
        }

        public static async Task ContinueOnUIThreadAsync(this Task Task, CoreDispatcher Dispatcher, Action action)
        {
            await Task.ContinueWith(async task => await VisualTools.OnUIThreadAsync(Dispatcher, action));
        }

        private class DummyDO : DependencyObject
        {
            public object Value
            {
                get { return (object)GetValue(ValueProperty); }
                set { SetValue(ValueProperty, value); }
            }

            public static readonly DependencyProperty ValueProperty =
                DependencyProperty.Register("Value", typeof(object), typeof(DummyDO), new PropertyMetadata(null));
        }

        public static object EvalBinding(Windows.UI.Xaml.Data.Binding b)
        {
            DummyDO d = new DummyDO();
            BindingOperations.SetBinding(d, DummyDO.ValueProperty, b);
            return d.Value;
        }

        public static DependencyObject GetBaseParent(this DependencyObject ItemForParent)
        {
            var parent = ItemForParent;
            while (((FrameworkElement)parent).Parent != null) parent = ((FrameworkElement)parent).Parent;
            return parent;
        }
    }
}