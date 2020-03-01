using System.Windows;

namespace Fluid.UI.Windows.Controls.Helpers
{
    public class TabControl
    {
        /// <summary>
        ///     Свойство ширины вкладки.
        /// </summary>
        public static readonly DependencyProperty TabWidthProperty =
            DependencyProperty.RegisterAttached(
                "TabWidth", typeof(double), typeof(TabControl),
                new PropertyMetadata(double.NaN));

        /// <summary>
        ///     Получает ширину вкладки.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static double GetTabWidth(DependencyObject obj)
        {
            return (double) obj.GetValue(TabWidthProperty);
        }

        /// <summary>
        ///     Задает ширину вкладки.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        public static void SetTabWidth(DependencyObject obj, double value)
        {
            obj.SetValue(TabWidthProperty, value);
        }
    }
}