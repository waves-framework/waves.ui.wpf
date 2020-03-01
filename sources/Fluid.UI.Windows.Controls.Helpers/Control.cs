using System.Windows;

namespace Fluid.UI.Windows.Controls.Helpers
{
    public class Control
    {
        /// <summary>
        ///     Свойство радиуса сглаживания углов.
        /// </summary>
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.RegisterAttached("CornerRadius", typeof(CornerRadius), typeof(Control),
                new PropertyMetadata(new CornerRadius(0, 0, 0, 0)));

        /// <summary>
        ///     Получает свойства радиуса сглаживания углов.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static CornerRadius GetCornerRadius(DependencyObject obj)
        {
            return (CornerRadius) obj.GetValue(CornerRadiusProperty);
        }

        /// <summary>
        ///     Задает свойство радиуса сглаживания углов.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        public static void SetCornerRadius(DependencyObject obj, CornerRadius value)
        {
            obj.SetValue(CornerRadiusProperty, value);
        }
    }
}