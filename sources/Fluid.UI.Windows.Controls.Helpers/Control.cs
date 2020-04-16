using System.Windows;

namespace Fluid.UI.Windows.Controls.Helpers
{
    /// <summary>
    ///     Control's dependency property helper.
    /// </summary>
    public class Control
    {
        /// <summary>
        ///     Gets or sets control's "Corner Radius" property.
        /// </summary>
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.RegisterAttached("CornerRadius", typeof(CornerRadius), typeof(Control),
                new PropertyMetadata(new CornerRadius(0, 0, 0, 0)));

        /// <summary>
        ///     Gets control's "Corner Radius".
        /// </summary>
        /// <param name="obj">Dependency object.</param>
        /// <returns>Corner radius.</returns>
        public static CornerRadius GetCornerRadius(DependencyObject obj)
        {
            return (CornerRadius) obj.GetValue(CornerRadiusProperty);
        }

        /// <summary>
        ///     Sets control's "Corner Radius" property.
        /// </summary>
        /// <param name="obj">Dependency object.</param>
        /// <param name="value">Corner radius.</param>
        public static void SetCornerRadius(DependencyObject obj, CornerRadius value)
        {
            obj.SetValue(CornerRadiusProperty, value);
        }
    }
}