using System;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;

namespace Fluid.UI.Windows.Extensions
{
    /// <summary>
    ///     Window extension.
    /// </summary>
    internal static class Window
    {
        /// <summary>
        ///     Execute action for window from child dependency object.
        /// </summary>
        /// <param name="childDependencyObject">Child dependency object.</param>
        /// <param name="action">Action.</param>
        public static void ForWindowFromChild(this object childDependencyObject, Action<System.Windows.Window> action)
        {
            var element = childDependencyObject as DependencyObject;
            while (element != null)
            {
                element = VisualTreeHelper.GetParent(element);
                if (!(element is System.Windows.Window)) continue;
                action(element as System.Windows.Window);
                break;
            }
        }

        /// <summary>
        ///     Returns windows from child object.
        /// </summary>
        /// <param name="childDependencyObject">Child dependency object.</param>
        /// <returns>Window.</returns>
        public static System.Windows.Window GetWindow(this object childDependencyObject)
        {
            var element = childDependencyObject as DependencyObject;
            while (element != null)
            {
                element = VisualTreeHelper.GetParent(element);
                if (element is System.Windows.Window window) return window;
            }

            return null;
        }

        /// <summary>
        ///     Execute action for window from template.
        /// </summary>
        /// <param name="templateFrameworkElement">Template framework element.</param>
        /// <param name="action">Action.</param>
        public static void ForWindowFromTemplate(this object templateFrameworkElement,
            Action<System.Windows.Window> action)
        {
            if (((FrameworkElement) templateFrameworkElement).TemplatedParent is System.Windows.Window window)
                action(window);
        }

        /// <summary>
        ///     Gets window handle (IntPtr).
        /// </summary>
        /// <param name="window">Window.</param>
        /// <returns>Pointer / Handle.</returns>
        public static IntPtr GetWindowHandle(this System.Windows.Window window)
        {
            var helper = new WindowInteropHelper(window);
            return helper.Handle;
        }
    }
}