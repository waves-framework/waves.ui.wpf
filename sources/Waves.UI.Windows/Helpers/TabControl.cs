using System.Windows;

namespace Waves.UI.Windows.Helpers
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
        /// Gets or sets "IsContentVisible" dependecy property. 
        /// </summary>
        public static readonly DependencyProperty IsContentVisibleProperty =
            DependencyProperty.RegisterAttached(
                "IsContentVisible", typeof(bool), typeof(TabControl),
                new PropertyMetadata(true));

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
        ///     Gets whether is content visible.
        /// </summary>
        /// <param name="obj">Dependency object.</param>
        /// <returns>Returns whether in content visible value.</returns>
        public static bool GetIsContentVisible(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsContentVisibleProperty);
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

        /// <summary>
        ///     Sets whether is content visible.
        /// </summary>
        /// <param name="obj">Dependency object.</param>
        /// <param name="value">Is content visible value.</param>
        public static void SetIsContentVisible(DependencyObject obj, bool value)
        {
            obj.SetValue(IsContentVisibleProperty, value);
        }
    }
}