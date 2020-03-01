using System.Windows;

namespace Fluid.UI.Windows.Controls.Helpers
{
    public class TextBox
    {
        /// <summary>
        ///     Свойство описания поля ввода.
        /// </summary>
        public static readonly DependencyProperty DescriptionProperty =
            DependencyProperty.RegisterAttached("Description", typeof(string), typeof(TextBox),
                new UIPropertyMetadata(string.Empty));

        /// <summary>
        ///     Получает свойство описания поля ввода.
        /// </summary>
        public static string GetDescription(DependencyObject obj)
        {
            return (string) obj.GetValue(DescriptionProperty);
        }

        /// <summary>
        ///     Задает свойство описания поля ввода.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        public static void SetDescription(DependencyObject obj, string value)
        {
            obj.SetValue(DescriptionProperty, value);
        }
    }
}