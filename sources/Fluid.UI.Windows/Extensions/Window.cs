namespace Fluid.UI.Windows.Extensions
{
    internal static class Window
    {
        /// <summary>
        ///     ???
        /// </summary>
        /// <param name="childDependencyObject"></param>
        /// <param name="action"></param>
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
        ///     Вовращает окно
        /// </summary>
        /// <param name="childDependencyObject"></param>
        /// <returns></returns>
        public static System.Windows.Window GetWindow(this object childDependencyObject)
        {
            var element = childDependencyObject as DependencyObject;
            while (element != null)
            {
                element = VisualTreeHelper.GetParent(element);
                if (element is System.Windows.Window) return element as System.Windows.Window;
            }

            return null;
        }

        /// <summary>
        ///     ???
        /// </summary>
        /// <param name="templateFrameworkElement"></param>
        /// <param name="action"></param>
        public static void ForWindowFromTemplate(this object templateFrameworkElement,
            Action<System.Windows.Window> action)
        {
            var window = ((FrameworkElement) templateFrameworkElement).TemplatedParent as System.Windows.Window;
            if (window != null) action(window);
        }

        /// <summary>
        ///     Получает указатель на окно
        /// </summary>
        /// <param name="window"></param>
        /// <returns></returns>
        public static IntPtr GetWindowHandle(this System.Windows.Window window)
        {
            var helper = new WindowInteropHelper(window);
            return helper.Handle;
        }
    }
}