using System;
using System.Windows;
using System.Windows.Threading;

namespace Fluid.UI.Windows.Helpers
{
    /// <summary>
    /// Dispatcher Helper.
    /// </summary>
    public class DispatcherHelper
    {
        /// <summary>
        /// Invoke action throw dispatcher.
        /// </summary>
        /// <param name="action">Actions.</param>
        public static void Invoke(Action action)
        {
            var dispatchObject = Application.Current.Dispatcher;
            if (dispatchObject == null || dispatchObject.CheckAccess())
            {
                action();
            }
            else
            {
                dispatchObject.Invoke(action);
            }
        }
    }
}