using System.Windows;

namespace Fluid.UI.Windows.Controls.Helpers
{
    /// <summary>
    ///     Tab control dependency property helper.
    /// </summary>
    public class TabControl
    {
        /// <summary>
        ///     Gets or sets "Tab Width" dependency property.
        /// </summary>
        public static readonly DependencyProperty TabWidthProperty =
            DependencyProperty.RegisterAttached(
                "TabWidth", typeof(double), typeof(TabControl),
                new PropertyMetadata(double.NaN));

        /// <summary>
        ///     Gets tab width.
        /// </summary>
        /// <param name="obj">Dependency object.</param>
        /// <returns>Tab width value.</returns>
        public static double GetTabWidth(DependencyObject obj)
        {
            return (double) obj.GetValue(TabWidthProperty);
        }

        /// <summary>
        ///     Sets tab width.
        /// </summary>
        /// <param name="obj">Dependency object.</param>
        /// <param name="value">Tab width value.</param>
        public static void SetTabWidth(DependencyObject obj, double value)
        {
            obj.SetValue(TabWidthProperty, value);
        }
    }
}